using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : ICreature
    {
        int MpMax { get; set; }
        int MpCur { get; set; }
        int Level { get; set; }
        int Xp { get; set; }
        int Gold { get; set; }

        public List<IItem> Inventory { get; set; }
        public List<IItem> QuestLog { get; set; }

        public ItemArmour HeadSlot { get; set; }
        public ItemArmour ChestSlot { get; set; }
        public ItemArmour LegSlot { get; set; }
        public ItemArmour FootSlot { get; set; }
        public ItemArmour HandSlot { get; set; }

        public ItemWeapon Weapon { get; set; }

        public Player(int hpMax, int hpCur, int mpMax, int mpCur, int lv, int xp, int gp) : base(hpMax, hpCur)
        {
            MpMax = mpMax;
            MpCur = mpCur;
            Level = lv;
            Xp = xp;
            Gold = gp;

            List<IItem> Inventory = new List<IItem>();
            List<Quest> QuestLog = new List<Quest>();
        }
    }
}
