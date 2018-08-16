using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ListLocations
    {
        public static readonly List<ILocation> LocList = new List<ILocation>();

        public const int LOCN_ID_HOUSE = 0;
        public const int LOCN_ID_FOREST = 1;
        public const int LOCN_ID_DEEP_FOREST = 2;
        public const int LOCN_ID_SPIDER_NEST = 3;
        public const int LOCN_ID_GRAVEYARD = 4;
        public const int LOCN_ID_CAVE = 5;

        public static void PopulateLocList()
        {
            ILocation house = new ILocation(LOCN_ID_HOUSE, "Your House", "This is your home.");

            ILocation forest = new ILocation(LOCN_ID_FOREST, "The Forest", "It's very quiet and shady.")
            {
                MonsterHere = IMonster.MonsterID(2)
            };

            ILocation deepforest = new ILocation(LOCN_ID_DEEP_FOREST, "Deep Forest", "It's dark and damp this far into the woods.")
            {
                MonsterHere = IMonster.MonsterID(1)
            };

            ILocation spidernest = new ILocation(LOCN_ID_SPIDER_NEST, "Spider's Nest", "There are webs everywhere...")
            {
                MonsterHere = IMonster.MonsterID(3)
            };

            ILocation graveyard = new ILocation(LOCN_ID_GRAVEYARD, "The Graveyard", "It's always eerie walking through a graveyard in the dark.")
            {
                MonsterHere = IMonster.MonsterID(0)
            };

            ILocation cave = new ILocation(LOCN_ID_CAVE, "Cave", "The mouth of a cave. Looks like someone's living in it.")
            {
                //NpcHere = null
            };

            house.LocToNorth = forest;

            forest.LocToNorth = deepforest;
            forest.LocToEast = spidernest;
            forest.LocToSouth = house;
            forest.LocToWest = graveyard;

            deepforest.LocToNorth = cave;
            deepforest.LocToSouth = forest;

            spidernest.LocToWest = forest;

            graveyard.LocToEast = forest;

            LocList.Add(house);
            LocList.Add(forest);
            LocList.Add(deepforest);
            LocList.Add(spidernest);
            LocList.Add(graveyard);
            LocList.Add(cave);
        }
    }
}
