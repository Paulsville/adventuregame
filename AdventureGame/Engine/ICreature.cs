using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ICreature
    {
        int HpMax { get; set; }
        int HpCur { get; set; }

        public ICreature(int hpMax, int hpCur)
        {
            HpMax = hpMax;
            HpCur = hpCur;

        }
    }
}
