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

namespace Adventure
{
    public partial class AdventureGame : Form
    {
        public AdventureGame()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            Player player = new Player("Player", 10, 10, 5, 5, 1, 0, 0);
        }
    }
}
