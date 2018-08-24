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
            ListItems.PopulateItemList();
            ListMonsters.PopulateMonsterList();
            ListQuests.PopulateQuestList();
            ListNpcs.PopulateNpcList();
            ListLocations.PopulateLocList();
        }
    }
}
