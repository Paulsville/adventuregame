using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Creature
    {
        int HpMax { get; set; }
        int HpCur { get; set; }

        public Creature(int hpMax, int hpCur)
        {
            HpMax = hpMax;
            HpCur = hpCur;

        }
    }
}
