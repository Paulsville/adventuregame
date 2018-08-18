using System;
using System.Windows.Forms;
using Engine;

namespace AdventureMain
{
    public partial class AdventureMain : Form
    {
        Player _player = new Player(10, 10, 1, 0, 20);

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
        }

        private void BtnMoveNorth_Click(object sender, EventArgs e)
        {
            if(_player.PlayerLocation.LocToNorth != null)
            {
                _player.PlayerLocation = _player.PlayerLocation.LocToNorth;
                lblPlayerLocation.Text = _player.PlayerLocation.Name;
                infoBox.Text = Utils.LocInfoWriter(_player);
            }
        }

        private void BtnMoveEast_Click(object sender, EventArgs e)
        {
            if (_player.PlayerLocation.LocToEast != null)
            {
                _player.PlayerLocation = _player.PlayerLocation.LocToEast;
                lblPlayerLocation.Text = _player.PlayerLocation.Name;
                infoBox.Text = Utils.LocInfoWriter(_player);
            }
        }

        private void BtnMoveSouth_Click(object sender, EventArgs e)
        {
            if (_player.PlayerLocation.LocToSouth != null)
            {
                _player.PlayerLocation = _player.PlayerLocation.LocToSouth;
                lblPlayerLocation.Text = _player.PlayerLocation.Name;
                infoBox.Text = Utils.LocInfoWriter(_player);
            }
        }

        private void BtnMoveWest_Click(object sender, EventArgs e)
        {
            if (_player.PlayerLocation.LocToWest != null)
            {
                _player.PlayerLocation = _player.PlayerLocation.LocToWest;
                lblPlayerLocation.Text = _player.PlayerLocation.Name;
                infoBox.Text = Utils.LocInfoWriter(_player);
            }
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
                    playerDmgMess = "You hit " + attacker.Name + " for " + dmg + " damage.";


                    if(attacker.HpCur <= 0)
                    {
                        monsterDmgMess = "The " + attacker.Name + " dies.";
                        attacker.HpCur = 0;
                        _player.Xp += attacker.XpReward;
                        lblXp.Text = _player.Xp.ToString();

                        #region loot

                        foreach(LootItem item in attacker.LootTable)
                        {
                            int lootRoll = Utils.NumberBetween(0, 100);
                            if(lootRoll <= item.Chance)
                            {
                                int itemQty = Utils.NumberBetween(item.QtyMin, item.QtyMax);
                                for(int i = 0; i < itemQty; i++)
                                {
                                    _player.Inventory.Add(item.Item);
                                }
                                string lootMess = "You receive item: " + item.Item.ItmName + " x" + itemQty;
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        int monsterDmg = Utils.NumberBetween(attacker.DmgMin, attacker.DmgMax);
                        _player.HpCur = _player.HpCur - monsterDmg;

                        lblHp.Text = _player.HpCur.ToString();

                        if(_player.HpCur <= 0)
                        {
                            //ur ded lol
                        }

                        lblHp.Text = _player.HpCur.ToString();
                    }
                }
                

            }
        }
    }
}
