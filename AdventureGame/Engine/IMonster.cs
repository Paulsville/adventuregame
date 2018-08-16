using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class IMonster : ICreature
    {
        int ID { get; set; }
        public string Name { get; set; }
        int DmgMin { get; set; }
        int DmgMax { get; set; }
        int XpReward { get; set; }
        public List<LootItem> LootTable { get; set; }

        public IMonster(int id, string name, int hpMax, int hpCur, int dmgMin, int dmgMax, int xpReward) : base(hpMax, hpCur)
        {
            ID = id;
            Name = name;
            DmgMin = dmgMin;
            DmgMax = DmgMax;
            XpReward = xpReward;
            LootTable = new List<LootItem>();
        }

        public static IMonster MonsterID(int id)
        {
            foreach (IMonster monster in ListMonsters.MonsterList)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }
    }
}
