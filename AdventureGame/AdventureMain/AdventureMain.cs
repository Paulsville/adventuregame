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
            Inventory = new List<InventoryItem>(20),
            QuestLog = new List<IQuest>(25)
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

            //draw quest log
            QuestView.ColumnCount = 4;
            QuestView.Columns[0].Name = "Quest";
            QuestView.Columns[0].Width = 100;
            QuestView.Columns[1].Name = "Description";
            QuestView.Columns[1].Width = 200;
            QuestView.Columns[2].Name = "Progress";
            QuestView.Columns[2].Width = 100;
            QuestView.Columns[3].Name = "ID";
            QuestView.Columns[3].Visible = false;

            //initialise minimap

            MinimapGrid.ColumnCount = 5;
            MinimapGrid.RowCount = 5;
            MinimapGrid.RowTemplate.Height = 50;
            MinimapGrid.Columns[0].Width = 70;
            MinimapGrid.Columns[1].Width = 70;
            MinimapGrid.Columns[2].Width = 70;
            MinimapGrid.Columns[3].Width = 70;
            MinimapGrid.Columns[4].Width = 70;



            //starting properties and equipment
            _player.PosX = 0;
            _player.PosY = 0;
            _player.Weapon = (IWeapon)IItem.ItemID(0);
            _player.Inventory.Add(new InventoryItem(IItem.ItemID(201), 1));
            _player.Inventory.Add(new InventoryItem(IItem.ItemID(100), 5));

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
                            break;
                        case 'e':
                            if (ListLocations.GetLocAt(_player.PosX, _player.PosY + 1) != null)
                            {
                                _player.PosY++;
                            }
                            break;
                        case 's':
                            if (ListLocations.GetLocAt(_player.PosX - 1, _player.PosY) != null)
                            {
                                _player.PosX--;
                            }
                            break;
                        case 'w':
                            if (ListLocations.GetLocAt(_player.PosX, _player.PosY - 1) != null)
                            {
                                _player.PosY--;
                            }
                            break;
                        default:
                            break;
                    }

                    _player.PlayerLocation = ListLocations.GetLocAt(_player.PosX, _player.PosY);

                    if (_player.PlayerLocation.MonsterHere != null)
                    {
                        _player.PlayerLocation.SpawnedMonster = new Monster(_player.PlayerLocation.MonsterHere);
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

        private void BtnAttack_Click(object sender, EventArgs e)
        {
            if(!_player.Dead)
            {
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
                        if (dmg == 0)
                        {
                            playerDmgMess = "You miss the " + attacker.Name;
                        }
                        else
                        {
                            playerDmgMess = "You hit the " + attacker.Name + " for " + dmg + " damage.";
                        }
                        #endregion

                        #region postcombat
                        if (attacker.HpCur <= 0)
                        {
                            _player.Combat = false;
                            monsterDmgMess = "The " + attacker.Name + " dies.";
                            attacker.HpCur = -1;
                            infoBox.Text = Utils.LocInfoWriter(_player) + "\n\n" + playerDmgMess;

                            infoBox.Text += "\n\n" + monsterDmgMess;

                            if (attacker.GoldReward > 0)
                            {
                                infoBox.Text += "You receive " + attacker.XpReward + " experience and find " + attacker.GoldReward + " gold.";
                                _player.Gold += attacker.GoldReward;
                            }
                            else
                            {
                                infoBox.Text += "You receive " + attacker.XpReward + " experience.";
                            }


                            _player.Xp += attacker.XpReward;

                            foreach (LootItem item in attacker.LootTable)
                            {
                                int lootRoll = Utils.NumberBetween(0, 100);
                                if (lootRoll <= item.Chance)
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
                        infoBox.Text = Utils.LocInfoWriter(_player) + "\n\nYou hit the dead " + attacker.Name + ". Was that really necessary?";
                    }
                }
                else
                {
                    infoBox.Text = Utils.LocInfoWriter(_player) + "\n\nYou wave your sword around a bit. Swish swish.";
                }
            }
            
        }

        private void BtnTalk_Click(object sender, EventArgs e)
        {
            if (_player.PlayerLocation.NpcHere != null)
            {
                INpc npc = _player.PlayerLocation.NpcHere;
                if (npc.GiveQuests.First() == null)
                {
                    infoBox.Text = "\"" + Utils.DialogueWriter(_player) + "\"";
                }
                else
                {
                    IQuest q = npc.GiveQuests.First();
                    if (q.QuestPreReq != null)
                    {
                        if (_player.QuestLog.Contains(q.QuestPreReq))
                        {
                            int i = _player.QuestLog.IndexOf(q.QuestPreReq);
                            if (_player.QuestLog[i].Completed == true)
                            {
                                _player.QuestLog.Add(q);
                                infoBox.Text = "Quest Accepted: " + q.QuestName + "\n\n\"" + q.QuestDialogue + "\"";
                            }
                            else
                            {
                                infoBox.Text = "\"" + Utils.DialogueWriter(_player) + "\"";
                            }
                        }
                        else
                        {
                            infoBox.Text = "\"" + Utils.DialogueWriter(_player) + "\"";
                        }
                    }
                    else
                    {
                        _player.QuestLog.Add(q);
                        infoBox.Text = "Quest Accepted: " + q.QuestName + "\n\n\"" + q.QuestDialogue + "\"";
                    }
                }

                UpdateQuests();
            }
            else if (_player.PlayerLocation.MonsterHere != null)
            {
                if (_player.Combat)
                {
                    infoBox.Text = Utils.LocInfoWriter(_player) + "\n\nThe " + _player.PlayerLocation.MonsterHere.Name + " is too busy attacking you to talk!";
                }
                else
                {
                    if (_player.PlayerLocation.SpawnedMonster.HpCur == 0)
                    {
                        infoBox.Text = Utils.LocInfoWriter(_player) + "\n\nThe " + _player.PlayerLocation.MonsterHere.Name + " eyes you warily.";
                    }
                }
            }
            else
            {
                infoBox.Text = Utils.LocInfoWriter(_player) + "\n\nThere's nobody here to talk to.";
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if(_player.PlayerLocation.ItemHere != null)
            {
                AddInventoryItem(_player.PlayerLocation.ItemHere);
            }
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

        private void QuestView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            IQuest q = IQuest.QuestID(Int32.Parse(QuestView.Rows[i].Cells[3].Value.ToString()));
            if (_player.Inventory.FirstOrDefault(itm => itm.Itm == q.ItemToComplete.Item) != null)
            {
                InventoryItem qItm = _player.Inventory.FirstOrDefault(itm => itm.Itm == q.ItemToComplete.Item);
                if (qItm.ItmQty >= q.ItemToComplete.ReqdQty)
                {
                    try
                    {
                        if (_player.PlayerLocation.NpcHere.GiveQuests.Contains(q))
                        {
                            if(qItm.ItmQty > q.ItemToComplete.ReqdQty)
                            {
                                _player.Inventory[_player.Inventory.IndexOf(qItm)].ItmQty -= q.ItemToComplete.ReqdQty;
                            }
                            else
                            {
                                _player.Inventory.Remove(qItm);
                            }
                            UpdateInventory();

                            
                            _player.Xp += q.RewardXp;

                            if(q.RewardGold > 0)
                            {
                                _player.Gold += q.RewardGold;
                                infoBox.Text = "Quest Completed: " + q.QuestName + "\n\n\"" + q.RewardDialogue + "\"\n\nYou receive " + q.RewardXp
                                    + " experience and " + q.RewardGold + " gold.";
                            }
                            else
                            {
                                infoBox.Text = "Quest Completed: " + q.QuestName + "\n\n\"" + q.RewardDialogue + "\"\n\nYou receive " + q.RewardXp
                                    + " experience.";
                            }
                           

                            int questIndex = _player.QuestLog.IndexOf(q);

                            _player.QuestLog[questIndex].Completed = true;

                            _player.PlayerLocation.NpcHere.GiveQuests.Remove(q);

                            UpdateQuests();
                        }
                    }
                    catch { }

                }

            }
        }
        
        private void UpdateInventory()
        {
            InventoryView.Rows.Clear();
            foreach(InventoryItem item in _player.Inventory)
            {
                InventoryView.Rows.Add(new[] { item.Itm.ItmName, item.ItmQty.ToString(), item.Itm.ItmDesc, _player.Inventory.IndexOf(item).ToString()});
            }
            UpdateQuests();
        }

        private void UpdateQuests()
        {
            QuestView.Rows.Clear();
            foreach(IQuest q in _player.QuestLog)
            {
                if(!q.Completed)
                {
                    IItem reqdItm = q.ItemToComplete.Item;
                    string playerQty;
                    try
                    {
                        playerQty = _player.Inventory.FirstOrDefault(i => i.Itm == reqdItm).ItmQty.ToString();
                    }
                    catch
                    {
                        playerQty = "0";
                    }

                    int reqdQty = q.ItemToComplete.ReqdQty;
                    QuestView.Rows.Add(new[] { q.QuestName, q.QuestDesc, q.ItemToComplete.Item.ItmName.ToString() + " " + playerQty + " / " + reqdQty, q.ID.ToString() });
                }
                
            }

            for (int i = 0; i < QuestView.RowCount; i++)
            {
                IQuest q = IQuest.QuestID(Int32.Parse(QuestView.Rows[i].Cells[3].Value.ToString()));
                int qIndex = _player.QuestLog.IndexOf(q);

                    if (_player.Inventory.FirstOrDefault(itm => itm.Itm == q.ItemToComplete.Item) != null)
                    {
                        InventoryItem qItm = _player.Inventory.FirstOrDefault(itm => itm.Itm == q.ItemToComplete.Item);
                        if (qItm.ItmQty >= q.ItemToComplete.ReqdQty)
                        {
                            try
                            {
                                if (_player.PlayerLocation.NpcHere.GiveQuests.Contains(q))
                                {
                                    QuestView.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    QuestView.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                                }
                            }
                            catch
                            {
                                QuestView.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                            }

                        }

                    }
                
                
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
                    + "!\n\nYour maximum health has increased by 3.\n\nYour bonus damage has increased by 1.";
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

        private void AddInventoryItem(InventoryItem item)
        {
            if (_player.Inventory.FirstOrDefault(i => i == item) != null)
            {
                _player.Inventory.FirstOrDefault(i => i == item).ItmQty += item.ItmQty;
            }
            else
            {
                _player.Inventory.Add(item);
            }
            infoBox.Text += "\n\nYou receive item: " + item.Itm + " x" + item.ItmQty;
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
        }

        
    }
}
