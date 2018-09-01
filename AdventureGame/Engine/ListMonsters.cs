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
        public const int MONSTER_ID_MUSHROOMBOSS = 4;

        public static void PopulateMonsterList()
        {
            IMonster rat = new IMonster(MONSTER_ID_RAT, "Giant Rat", 10, 1, 1, 10, 1);
            rat.LootTable.Add(new LootItem(IItem.ItemID(100), 100, 1, 1));

            IMonster wolf = new IMonster(MONSTER_ID_WOLF, "Lone Wolf", 11, 2, 3, 15, 2);
            wolf.LootTable.Add(new LootItem(IItem.ItemID(101), 100, 1, 1));

            IMonster snake = new IMonster(MONSTER_ID_SNAKE, "Adder", 7, 0, 1, 10, 1);
            snake.LootTable.Add(new LootItem(IItem.ItemID(102), 100, 1, 1));

            IMonster spider = new IMonster(MONSTER_ID_SPIDER, "Giant Spider", 8, 2, 3, 15, 1);
            spider.LootTable.Add(new LootItem(IItem.ItemID(103), 100, 1, 2));

            IMonster mushroomboss = new IMonster(MONSTER_ID_MUSHROOMBOSS, "Man Eating Mushroom", 20, 3, 4, 25, 0);
            mushroomboss.LootTable.Add(new LootItem(IItem.ItemID(105), 100, 1, 1));

            MonsterList.Add(rat);
            MonsterList.Add(wolf);
            MonsterList.Add(snake);
            MonsterList.Add(spider);
            MonsterList.Add(mushroomboss);
        }
    }
}
