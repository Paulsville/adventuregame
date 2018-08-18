using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class IWeapon : IArmour
    {
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }

        public IWeapon(int id, string name, string desc, int bonusHP, int minDmg, int maxDmg) 
            : base(id, name, desc, bonusHP)
        {
            MinDmg = minDmg;
            MaxDmg = maxDmg;
        }
    }
}
