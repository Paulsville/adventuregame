using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ListMonsters
    {
        public static readonly List<IMonster> MonsterList = new List<IMonster>();

        public const int MONSTER_ID_RAT = 0;
        public const int MONSTER_ID_WOLF = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_SPIDER = 3;

        public static void PopulateMonsterList()
        {
            IMonster rat = new IMonster(MONSTER_ID_RAT, "Giant Rat", 10, 10, 1, 1, 10, 1);
            rat.LootTable.Add(new LootItem(IItem.ItemID(6), 100, 1, 1));

            IMonster wolf = new IMonster(MONSTER_ID_WOLF, "Lone Wolf", 15, 15, 0, 2, 15, 2);
            wolf.LootTable.Add(new LootItem(IItem.ItemID(7), 100, 1, 1));

            IMonster snake = new IMonster(MONSTER_ID_SNAKE, "Adder", 7, 7, 0, 4, 10, 1);
            snake.LootTable.Add(new LootItem(IItem.ItemID(8), 100, 1, 1));

            IMonster spider = new IMonster(MONSTER_ID_SPIDER, "Giant Spider", 8, 8, 2, 3, 15, 1);
            spider.LootTable.Add(new LootItem(IItem.ItemID(9), 100, 1, 2));

            MonsterList.Add(rat);
            MonsterList.Add(wolf);
            MonsterList.Add(snake);
            MonsterList.Add(spider);
        }
    }
}
