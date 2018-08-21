using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster : IMonster
    {
        public int HpCur { get; set; }

        public Monster(int id, string name, int hpMax, int dmgMin, int dmgMax, int xpReward, int goldReward) : base(id, name, hpMax, dmgMin, dmgMax, xpReward, goldReward)
        {
            HpCur = hpMax;
        }
    }
}
