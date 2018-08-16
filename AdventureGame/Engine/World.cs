using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class World
    {
        public static void WorldBuilder()
        {
            ListLocations.PopulateLocList();
            ListItems.PopulateItemList();
            ListNpcs.PopulateNpcList();
            ListQuests.PopulateQuestList();
            ListMonsters.PopulateMonsterList();
        }
    }
}
