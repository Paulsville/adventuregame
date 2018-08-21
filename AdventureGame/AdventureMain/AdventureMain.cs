using System;
using System.Windows.Forms;
using Engine;
using System.Collections.Generic;

namespace AdventureMain
{
    public partial class AdventureMain : Form
    {
        Player _player = new Player(10, 10, 1, 0, 20)
        {
            Inventory = new List<InventoryItem>(20)
        };

        public AdventureMain()
        {
            InitializeComponent();

            World.WorldBuilder();

            _player.PlayerLocation = ILocation.LocationID(0);

            _player.Weapon = (IWeapon)IItem.ItemID(0);
            
            lblHp.Text = _player.HpCur.ToString();
            lblLv.Text = _player.Level.ToString();
            lblXp.Text = _player.Xp.ToString();
            lblGp.Text = _player.Gold.ToString();
            infoBox.Text = Utils.LocInfoWriter(_player);

            InventoryView.ColumnCount = 3;
            InventoryView.Columns[0].Name = "Item";
            InventoryView.Columns[0].Width = 90;
            InventoryView.Columns[1].Name = "Qty";
            InventoryView.Columns[1].Width = 30;
            InventoryView.Columns[2].Name = "Details";
            InventoryView.Columns[2].Width = 180;
        }

        private void BtnMoveNorth_Click(object sender, EventArgs e)
        {
            MoveTo('n');
        }

        private void BtnMoveEast_Click(object sender, EventArgs e)
        {
            MoveTo('e');
        }

        private void BtnMoveSouth_Click(object sender, EventArgs e)
        {
            MoveTo('s');
        }

        private void BtnMoveWest_Click(object sender, EventArgs e)
        {
            MoveTo('w');
        }

        private void BtnInteract_Click(object sender, EventArgs e)
        {
            if (_player.PlayerLocation.MonsterHere != null)
            {
                string playerDmgMess;
                string monsterDmgMess;
                IMonster attacker = _player.PlayerLocation.MonsterHere;
                if (attacker.HpCur > 0)
                {
                    _player.Combat = true;
                    int dmg;
                    try
                    {
                        dmg = Utils.NumberBetween(_player.Weapon.MinDmg, _player.Weapon.MaxDmg);
                        attacker.HpCur -= dmg;
                    }
                    catch
                    {
                        dmg = Utils.NumberBetween(0, 1);
                        attacker.HpCur -= dmg;
                    }
                    if(dmg == 0)
                    {
                        playerDmgMess = "You miss the " + attacker.Name;
                    }
                    else
                    {
                        playerDmgMess = "You hit the " + attacker.Name + " for " + dmg + " damage.";
                    }
                    

                    if(attacker.HpCur <= 0)
                    {
                        _player.Combat = false;
                        monsterDmgMess = "The " + attacker.Name + " dies.";
                        attacker.HpCur = -1;
                        infoBox.Text = Utils.LocInfoWriter(_player) + "\n\n" + playerDmgMess;

                        infoBox.Text += "\n\n" + monsterDmgMess;

                        #region postcombat

                        infoBox.Text += "You receive " + attacker.XpReward + " experience and find " + attacker.GoldReward + " gold.";
                        _player.Gold += attacker.GoldReward;
                        _player.Xp += attacker.XpReward;


                        if(CheckForLevelUp())
                        {
                            _player.Level++;
                            infoBox.Text += "\n\nYou have reached level " + _player.Level.ToString() + "!";
                        }

                        lblGp.Text = _player.Gold.ToString();
                        lblXp.Text = _player.Xp.ToString();

                        foreach (LootItem item in attacker.LootTable)
                        {
                            int lootRoll = Utils.NumberBetween(0, 100);
                            if(lootRoll <= item.Chance)
                            {
                                int itemQty = Utils.NumberBetween(item.QtyMin, item.QtyMax);
                                _player.Inventory.Add(new InventoryItem(item.Item, itemQty));
                                infoBox.Text += "\n\nYou receive item: " + item.Item.ItmName + " x" + itemQty;
                            }
                        }
                        UpdateInventory();
                        attacker.HpCur = 0;
                        #endregion
                    }
                    else
                    {
                        infoBox.Text = Utils.LocInfoWriter(_player) + "\n\n" + playerDmgMess;
                        int monsterDmg = Utils.NumberBetween(attacker.DmgMin, attacker.DmgMax);
                        _player.HpCur = _player.HpCur - monsterDmg;
                        if (monsterDmg == 0)
                        {
                            monsterDmgMess = "The " + attacker.Name + " misses you.";
                        }
                        else
                        {
                            monsterDmgMess = attacker.Name + " hits you for " + monsterDmg + " damage.";
                        }
                        infoBox.Text += "\n\n" + monsterDmgMess;

                        if (_player.HpCur <= 0)
                        {
                            _player.Dead = true;
                            _player.HpCur = 0;
                            infoBox.Text += "\n\nYou are dead!";
                        }

                        lblHp.Text = _player.HpCur.ToString();
                        
                    }
                }

                else
                {
                    infoBox.Text += "\n\nYou hit the dead " + attacker.Name + ". Was that really necessary?";
                }
                

            }
        }

        private void InventoryView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            infoBox.Text = "";
            
        }

        private void MoveTo(char dir)
        {
            ILocation loc = _player.PlayerLocation;
            if (!_player.Dead)
            {
                if (!_player.Combat)
                {
                    switch (dir)
                    {
                        case 'n':
                            if (loc.LocToNorth != null)
                            {
                                _player.PlayerLocation = loc.LocToNorth;
                            }
                            break;
                        case 'e':
                            if (loc.LocToEast != null)
                            {
                                _player.PlayerLocation = loc.LocToEast;
                            }
                            break;
                        case 's':
                            if (loc.LocToSouth != null)
                            {
                                _player.PlayerLocation = loc.LocToSouth;
                            }
                            break;
                        case 'w':
                            if (loc.LocToWest != null)
                            {
                                _player.PlayerLocation = loc.LocToWest;
                            }
                            break;
                        default:
                            break;
                    }
                    infoBox.Text = Utils.LocInfoWriter(_player);
                }
                else
                {
                    infoBox.Text = "You can't run while fighting a monster!\n\n" + "You see a "
                        + loc.MonsterHere.Name + " " + "(" + loc.MonsterHere.HpCur + "/" + loc.MonsterHere.HpMax + " HP).";
                }
            }
            UpdateInventory();
        }

        private void UpdateInventory()
        {
            InventoryView.Rows.Clear();
            foreach(InventoryItem item in _player.Inventory)
            {
                InventoryView.Rows.Add(new[] { item.Itm.ItmName, item.ItmQty.ToString(), item.Itm.ItmDesc });
            }
        }

        private bool CheckForLevelUp()
        {
            if(((_player.Xp / _player.Level) - 5) > 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
