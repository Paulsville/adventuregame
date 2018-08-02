using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster : Creature
    {
        int ID { get; set; }
        string Name { get; set; }
        int DmgMin { get; set; }
        int DmgMax { get; set; }
        int XpReward { get; set; }
        List<LootItem> LootTable { get; set; }

        public Monster(int id, string name, int hpMax, int hpCur, int dmgMin, int dmgMax, int xpReward, List<LootItem> lootTable) : base(hpMax, hpCur)
        {
            ID = id;
            Name = name;
            DmgMin = dmgMin;
            DmgMax = DmgMax;
            XpReward = xpReward;
            LootTable = lootTable;
        }
    }
}
