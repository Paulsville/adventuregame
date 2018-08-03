using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ItemWeapon : ItemArmour
    {
        int MinDmg { get; set; }
        int MaxDmg { get; set; }

        public ItemWeapon(int id, string name, string desc, int bonusHP, int bonusMP, int minDmg, int maxDmg) 
            : base(id, name, desc, bonusHP, bonusMP)
        {
            MinDmg = minDmg;
            MaxDmg = maxDmg;
        }
    }
}
