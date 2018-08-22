using System;
using System.Linq;
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

            #region startup

            //populate lists first thing - prevents nullreferences
            World.WorldBuilder();

            //draw inventory pane
            InventoryView.ColumnCount = 4;
            InventoryView.Columns[0].Name = "Item";
            InventoryView.Columns[0].Width = 90;
            InventoryView.Columns[1].Name = "Qty";
            InventoryView.Columns[1].Width = 30;
            InventoryView.Columns[2].Name = "Details";
            InventoryView.Columns[2].Width = 180;
            InventoryView.Columns[3].Name = "ID";
            InventoryView.Columns[3].Visible = false;

            //initialise minimap
            
            MinimapGrid.ColumnCount = 3;
            MinimapGrid.RowCount = 4;
            MinimapGrid.Columns[0].Name = "1";
            MinimapGrid.Columns[0].Width = 150;
            MinimapGrid.Columns[1].Name = "2";
            MinimapGrid.Columns[1].Width = 150;
            MinimapGrid.Columns[2].Name = "3";
            MinimapGrid.Columns[2].Width = 150;
            

            //starting properties and equipment
            _player.PlayerLocation = ILocation.LocationID(0);
            _player.Weapon = (IWeapon)IItem.ItemID(0);
            _player.Inventory.Add(new InventoryItem(IItem.ItemID(10), 1));

            //refresh labels
            UpdatePlayerLabels();
            infoBox.Text = Utils.LocInfoWriter(_player);
            UpdateInventory();
            UpdateMinimap();

            #endregion

        }

        #region movement

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
                    
                    if(_player.PlayerLocation.MonsterHere != null)
                    {
                        _player.PlayerLocation.SpawnedMonster = new Monster(_player.PlayerLocation.MonsterHere);
                        BtnInteract.Text = "Attack";
                    }
                    else
                    {
                        BtnInteract.Text = "";
                    }
                    infoBox.Text = Utils.LocInfoWriter(_player);
                }
                else
                {
                    infoBox.Text = "You can't run while fighting a monster!\n\n" + "You see a "
                        + loc.MonsterHere.Name + " " + "(" + loc.SpawnedMonster.HpCur + "/" + loc.MonsterHere.HpMax + " HP).";
                }
            }
            UpdateInventory();
            _player.PlayerLocation.Revealed = true;

            try
            {
                _player.PlayerLocation.LocToNorth.Discovered = true;
                _player.PlayerLocation.LocToEast.Discovered = true;
                _player.PlayerLocation.LocToSouth.Discovered = true;
                _player.PlayerLocation.LocToWest.Discovered = true;
            }
            catch { }

            UpdateMinimap();
        }

        #endregion

        private void BtnInteract_Click(object sender, EventArgs e)
        {
            #region combat
            if (_player.PlayerLocation.SpawnedMonster != null)
            {
                string playerDmgMess;
                string monsterDmgMess;
                Monster attacker = _player.PlayerLocation.SpawnedMonster;
                if (attacker.HpCur > 0)
                {
                    #region playerattack
                    _player.Combat = true;
                    int dmg;
                    try
                    {
                        dmg = Utils.NumberBetween(_player.Weapon.MinDmg, _player.Weapon.MaxDmg) + _player.DmgBonus;
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
                    #endregion

                    #region postcombat
                    if(attacker.HpCur <= 0)
                    {
                        _player.Combat = false;
                        monsterDmgMess = "The " + attacker.Name + " dies.";
                        attacker.HpCur = -1;
                        infoBox.Text = Utils.LocInfoWriter(_player) + "\n\n" + playerDmgMess;

                        infoBox.Text += "\n\n" + monsterDmgMess;

                        infoBox.Text += "You receive " + attacker.XpReward + " experience and find " + attacker.GoldReward + " gold.";
                        _player.Gold += attacker.GoldReward;
                        _player.Xp += attacker.XpReward;

                        foreach (LootItem item in attacker.LootTable)
                        {
                            int lootRoll = Utils.NumberBetween(0, 100);
                            if(lootRoll <= item.Chance)
                            {
                                int itemQty = Utils.NumberBetween(item.QtyMin, item.QtyMax);
                                AddInventoryItem(item.Item, itemQty);
                            }
                        }

                        UpdateInventory();
                        CheckForLevelUp();
                        UpdatePlayerLabels();
                        

                    }
                    #endregion

                    #region monsterattack
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

                        UpdatePlayerLabels();

                    }
                    #endregion
                }

                else
                {
                    infoBox.Text += "\n\nYou hit the dead " + attacker.Name + ". Was that really necessary?";
                } 
            }
            #endregion
        }

        private void InventoryView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int inventoryItemID = int.Parse(InventoryView.Rows[e.RowIndex].Cells[3].Value.ToString());
            IItem selection = _player.Inventory[inventoryItemID].Itm;

            #region potions
            if (selection.IsConsumable)
            {
                IConsumable healItem = (IConsumable)_player.Inventory[inventoryItemID].Itm;
                _player.HpCur += healItem.HpRestore;
                if(_player.HpCur > _player.HpMax)
                {
                    _player.HpCur = _player.HpMax;
                }

                lblHp.Text = _player.HpCur.ToString();

                if(_player.Inventory[inventoryItemID].ItmQty == 1)
                {
                    _player.Inventory.RemoveAt(inventoryItemID);
                }
                else
                {
                    _player.Inventory[inventoryItemID].ItmQty--;
                }
                UpdateInventory();

            }
            #endregion

        }
        
        private void UpdateInventory()
        {
            InventoryView.Rows.Clear();
            foreach(InventoryItem item in _player.Inventory)
            {
                InventoryView.Rows.Add(new[] { item.Itm.ItmName, item.ItmQty.ToString(), item.Itm.ItmDesc, _player.Inventory.IndexOf(item).ToString()});
            }
        }

        private void CheckForLevelUp()
        {
            if(((_player.Xp / _player.Level) - 5) > 10)
            {
                _player.Level++;
                _player.HpMax += 3;
                _player.DmgBonus++;
                _player.HpCur = _player.HpMax;
                infoBox.Text += "\n\nYou have reached level " + _player.Level.ToString() 
                    + "!\n\nYour maximum health has increased by 3.\n\nYour damage has increased by 1.";
            }
        }

        private void UpdatePlayerLabels()
        {
            lblHp.Text = _player.HpCur.ToString() + " / " + _player.HpMax.ToString();
            lblLv.Text = _player.Level.ToString();
            lblXp.Text = _player.Xp.ToString() + " / " + _player.Level * 15;
            lblGp.Text = _player.Gold.ToString();
        }

        private void AddInventoryItem(IItem item, int qty)
        {
            if(_player.Inventory.FirstOrDefault(i => i.Itm == item) != null)
            {
                _player.Inventory.FirstOrDefault(i => i.Itm == item).ItmQty += qty;
            }
            else
            {
                _player.Inventory.Add(new InventoryItem(item, qty));
            }
            infoBox.Text += "\n\nYou receive item: " + item.ItmName + " x" + qty;
            UpdateInventory();
            
        }

        private void UpdateMinimap()
        {
            foreach(ILocation loc in ListLocations.LocList)
            {
                if(loc.Revealed)
                {
                    MinimapGrid.Rows[loc.PosY - 1].Cells[loc.PosX - 1].Value = loc.Name;
                }
                else if(loc.Discovered)
                {
                    MinimapGrid.Rows[loc.PosY - 1].Cells[loc.PosX - 1].Value = "???";
                    MinimapGrid.Rows[loc.PosY - 1].Cells[loc.PosX - 1].Style.BackColor = System.Drawing.Color.White;
                }
                else
                {
                    MinimapGrid.Rows[loc.PosY - 1].Cells[loc.PosX - 1].Style.BackColor = System.Drawing.Color.Black;
                }
            }

            for(int i = 0; i < MinimapGrid.Rows.Count; i++)
            {
                for(int j = 0; j < MinimapGrid.ColumnCount; j++)
                {
                    var checkCell = MinimapGrid.Rows[i].Cells[j];
                    if(checkCell.Value == null)
                    {
                        checkCell.Style.BackColor = System.Drawing.Color.Black;
                    }
                }
                
            }

            MinimapGrid.Rows[_player.PlayerLocation.PosY - 1].Cells[_player.PlayerLocation.PosX - 1].Selected = true;

        }
    }
}
