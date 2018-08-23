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
            
            MinimapGrid.ColumnCount = 5;
            MinimapGrid.RowCount = 5;
            MinimapGrid.Columns[0].Width = 75;
            MinimapGrid.Columns[1].Width = 75;
            MinimapGrid.Columns[2].Width = 75;
            MinimapGrid.Columns[3].Width = 75;
            MinimapGrid.Columns[4].Width = 75;



            //starting properties and equipment
            _player.PosX = 0;
            _player.PosY = 0;
            _player.Weapon = (IWeapon)IItem.ItemID(0);
            _player.Inventory.Add(new InventoryItem(IItem.ItemID(10), 1));

            //refresh labels
            UpdatePlayerDetails();
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
                            if (ListLocations.GetLocAt(_player.PosX + 1, _player.PosY) != null)
                            {
                                _player.PosX++;
                            }
                            //_player.PlayerLocation = loc.LocToNorth;
                            break;
                        case 'e':
                            if (ListLocations.GetLocAt(_player.PosX, _player.PosY + 1) != null)
                            {
                                _player.PosY++;
                            }
                            //_player.PlayerLocation = loc.LocToEast;
                            break;
                        case 's':
                            if (ListLocations.GetLocAt(_player.PosX - 1, _player.PosY) != null)
                            {
                                _player.PosX--;
                            }
                            //_player.PlayerLocation = loc.LocToSouth;
                            break;
                        case 'w':
                            if (ListLocations.GetLocAt(_player.PosX, _player.PosY - 1) != null)
                            {
                                _player.PosY--;
                            }
                            //_player.PlayerLocation = loc.LocToWest;
                            break;
                        default:
                            break;
                    }

                    _player.PlayerLocation = ListLocations.GetLocAt(_player.PosX, _player.PosY);

                    if (_player.PlayerLocation.MonsterHere != null)
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

            #region set adjacent locations to discovered
            try
            {
                ListLocations.GetLocAt(_player.PosX, _player.PosY + 1).Discovered = true;
            }
            catch { }

            try
            {
                ListLocations.GetLocAt(_player.PosX, _player.PosY - 1).Discovered = true;
            }
            catch { }

            try
            {
                ListLocations.GetLocAt(_player.PosX + 1, _player.PosY).Discovered = true;
            }
            catch { }

            try
            {
                ListLocations.GetLocAt(_player.PosX - 1, _player.PosY).Discovered = true;
            }
            catch { }
            #endregion

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
                        UpdatePlayerDetails();
                        

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

                        UpdatePlayerDetails();

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

        private void UpdatePlayerDetails()
        {
            lblHp.Text = _player.HpCur.ToString() + " / " + _player.HpMax.ToString();
            lblLv.Text = _player.Level.ToString();
            lblXp.Text = _player.Xp.ToString() + " / " + _player.Level * 15;
            lblGp.Text = _player.Gold.ToString();
            _player.PlayerLocation = ListLocations.LocList.FirstOrDefault(l => l.PosX == _player.PosX && l.PosY == _player.PosY);
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
            
            for (int i = 0; i < MinimapGrid.Rows.Count; i++)
            {
                for (int j = 0; j < MinimapGrid.ColumnCount; j++)
                {
                    
                    var checkCell = MinimapGrid.Rows[i].Cells[j];
                    checkCell.Style.BackColor = System.Drawing.Color.White;
                    checkCell.Value = "";
                    ILocation loc = ListLocations.GetLocAt(_player.PosX - (i - 2), (j - 2) + _player.PosY);

                    if(loc != null)
                    {
                        if (loc.Revealed)
                        {
                            checkCell.Value = loc.Name;
                        }
                        else
                        {
                            if (loc.Discovered)
                            {
                                checkCell.Value = "???";
                                checkCell.Style.BackColor = System.Drawing.Color.White;
                            }
                            else
                            {
                                checkCell.Value = "";
                                checkCell.Style.BackColor = System.Drawing.Color.Black;
                            }
                        }
                    }
                    else
                    {
                        checkCell.Value = "";
                        checkCell.Style.BackColor = System.Drawing.Color.Black;
                    }
                        
                }
            }
            MinimapGrid.Rows[2].Cells[2].Value = _player.PlayerLocation.Name;
            MinimapGrid.Rows[2].Cells[2].Selected = true;



            /*ILocation ploc = _player.PlayerLocation;

            for (int i = 0; i < MinimapGrid.Rows.Count; i++)
            {
                for (int j = 0; j < MinimapGrid.ColumnCount; j++)
                {
                    var checkCell = MinimapGrid.Rows[i].Cells[j];

                    checkCell.Style.BackColor = System.Drawing.Color.White;
                    checkCell.Value = null;
                }
            }

            MinimapGrid.Rows[2].Cells[2].Value = ploc.Name;
            MinimapGrid.Rows[2].Cells[2].Selected = true;
            try
            {
                MinimapGrid.Rows[1].Cells[2].Value = ploc.LocToNorth.Name;
                MinimapGrid.Rows[0].Cells[2].Value = ploc.LocToNorth.LocToNorth.Name;
            }
            catch { }

            try
            {

                MinimapGrid.Rows[2].Cells[3].Value = ploc.LocToEast.Name;
                MinimapGrid.Rows[2].Cells[4].Value = ploc.LocToEast.LocToEast.Name;
            }
            catch { }

            try
            {
                MinimapGrid.Rows[3].Cells[2].Value = ploc.LocToSouth.Name;
                MinimapGrid.Rows[4].Cells[2].Value = ploc.LocToSouth.LocToSouth.Name;
            }
            catch { }

            try
            { 
            MinimapGrid.Rows[2].Cells[1].Value = ploc.LocToWest.Name;
                MinimapGrid.Rows[2].Cells[0].Value = ploc.LocToWest.LocToWest.Name;
            }
            catch { }

            for(int i = 0; i < MinimapGrid.Rows.Count; i++)
            {
                for(int j = 0; j < MinimapGrid.ColumnCount; j++)
                {
                    var checkCell = MinimapGrid.Rows[i].Cells[j];
                    if(checkCell.Value == null)
                    {
                        checkCell.Style.BackColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        checkCell.Style.BackColor = System.Drawing.Color.White;
                    }
                }
                
            }*/



        }
    }
}
