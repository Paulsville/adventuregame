using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ItemWeapon : Item
    {
        int SlotID { get; set; }
        int MinDmg { get; set; }
        int MaxDmg { get; set; }

        public ItemWeapon(int id, string name, string desc, int slotID, int minDmg, int maxDmg) : base(id, name, desc)
        {
            SlotID = slotID;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
        }
    }
}
