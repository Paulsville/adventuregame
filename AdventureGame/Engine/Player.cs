using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : Creature
    {
        string PlayerName { get; set; }
        int MpMax { get; set; }
        int MpCur { get; set; }
        int Level { get; set; }
        int Xp { get; set; }
        int Gold { get; set; }
        List<Item> Inventory { get; set; }

        public Player(string name, int hpMax, int hpCur, int mpMax, int mpCur, int lv, int xp, int gp) : base(hpMax, hpCur)
        {
            PlayerName = name;
            MpMax = mpMax;
            MpCur = mpCur;
            Level = lv;
            Xp = xp;
            Gold = gp;
        }
    }
}
