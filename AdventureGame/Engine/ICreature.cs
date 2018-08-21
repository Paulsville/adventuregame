using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ICreature
    {
        public int HpMax { get; set; }

        public ICreature(int hpMax)
        {
            HpMax = hpMax;

        }
    }
}
