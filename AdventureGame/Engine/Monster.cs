using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster
    {
        public IMonster MonsterType { get; set; }
        public string Name { get; set; }
        public int HpCur { get; set; }
        public int DmgMin { get; }
        public int DmgMax { get; }
        public int XpReward { get; set; }
        public int GoldReward { get; set; }
        public List<LootItem> LootTable { get; }

        public Monster(IMonster monsterType)
        {
            MonsterType = monsterType;

            Name = monsterType.Name;
            HpCur = monsterType.HpMax;
            DmgMin = monsterType.DmgMin;
            DmgMax = monsterType.DmgMax;
            XpReward = monsterType.XpReward;
            GoldReward = monsterType.GoldReward;
            LootTable = monsterType.LootTable;

        }
    }
}
