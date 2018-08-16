﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : ICreature
    {
        public int Level { get; set; }
        public int Xp { get; set; }
        public int Gold { get; set; }

        public List<IItem> Inventory { get; set; }
        public List<IItem> QuestLog { get; set; }

        public IArmour HeadSlot { get; set; }
        public IArmour ChestSlot { get; set; }
        public IArmour LegSlot { get; set; }
        public IArmour FootSlot { get; set; }
        public IArmour HandSlot { get; set; }

        public IWeapon Weapon { get; set; }

        public ILocation PlayerLocation { get; set; }

        public Player(int hpMax, int hpCur, int lv, int xp, int gp) : base(hpMax, hpCur)
        {
            Level = lv;
            Xp = xp;
            Gold = gp;

            List<IItem> Inventory = new List<IItem>();
            List<Quest> QuestLog = new List<Quest>();
        }
    }
}
