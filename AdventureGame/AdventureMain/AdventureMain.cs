using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
            lblHp.Text = _player.HpCur.ToString();
            lblLv.Text = _player.Level.ToString();
            lblXp.Text = _player.Xp.ToString();
            lblGp.Text = _player.Gold.ToString();
            lblPlayerLocation.Text = _player.PlayerLocation.Name;
            if(_player.PlayerLocation.MonsterHere != null)
            {
                lblMonsterHere.Text = _player.PlayerLocation.MonsterHere.Name;
            }
            else
            {
                lblMonsterHere.Text = "No monsters here!";
            }

        }

        private void AdventureMain_Load(object sender, EventArgs e)
        {

        }

        private void BtnMoveNorth_Click(object sender, EventArgs e)
        {
            if(_player.PlayerLocation.LocToNorth != null)
            {
                _player.PlayerLocation = _player.PlayerLocation.LocToNorth;
                lblPlayerLocation.Text = _player.PlayerLocation.Name;
                if (_player.PlayerLocation.MonsterHere != null)
                {
                    lblMonsterHere.Text = _player.PlayerLocation.MonsterHere.Name;
                }
                else
                {
                    lblMonsterHere.Text = "No monsters here!";
                }
            }
        }

        private void BtnMoveEast_Click(object sender, EventArgs e)
        {
            if (_player.PlayerLocation.LocToEast != null)
            {
                _player.PlayerLocation = _player.PlayerLocation.LocToEast;
                lblPlayerLocation.Text = _player.PlayerLocation.Name;
                if (_player.PlayerLocation.MonsterHere != null)
                {
                    lblMonsterHere.Text = _player.PlayerLocation.MonsterHere.Name;
                }
                else
                {
                    lblMonsterHere.Text = "No monsters here!";
                }
            }
        }

        private void BtnMoveSouth_Click(object sender, EventArgs e)
        {
            if (_player.PlayerLocation.LocToSouth != null)
            {
                _player.PlayerLocation = _player.PlayerLocation.LocToSouth;
                lblPlayerLocation.Text = _player.PlayerLocation.Name;
                if (_player.PlayerLocation.MonsterHere != null)
                {
                    lblMonsterHere.Text = _player.PlayerLocation.MonsterHere.Name;
                }
                else
                {
                    lblMonsterHere.Text = "No monsters here!";
                }
            }
        }

        private void BtnMoveWest_Click(object sender, EventArgs e)
        {
            if (_player.PlayerLocation.LocToWest != null)
            {
                _player.PlayerLocation = _player.PlayerLocation.LocToWest;
                lblPlayerLocation.Text = _player.PlayerLocation.Name;
                if (_player.PlayerLocation.MonsterHere != null)
                {
                    lblMonsterHere.Text = _player.PlayerLocation.MonsterHere.Name;
                }
                else
                {
                    lblMonsterHere.Text = "No monsters here!";
                }
            }
        }
    }
}
