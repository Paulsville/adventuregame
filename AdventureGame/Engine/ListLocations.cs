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
        public const int LOCN_ID_ALCHEMIST_HOUSE = 5;
        public const int LOCN_ID_MUSHROOM_GROVE = 6;

        public static void PopulateLocList()
        {
            ILocation house = new ILocation(LOCN_ID_HOUSE, "Your House", "This is your home.", 0, 0)
            {
                Discovered = true,
                Revealed = true
            };

            ILocation forest = new ILocation(LOCN_ID_FOREST, "Forest", "It's very quiet and shady.", 1, 0)
            {
                MonsterHere = IMonster.MonsterID(2),
                Discovered = true,
                ItemHere = new InventoryItem(IItem.ItemID(104), 1)
            };

            ILocation deepforest = new ILocation(LOCN_ID_DEEP_FOREST, "Deep Forest", "It's dark and damp this far into the woods.", 2, 0)
            {
                MonsterHere = IMonster.MonsterID(1),
                ItemHere = new InventoryItem(IItem.ItemID(104), 1)
            };

            ILocation spidernest = new ILocation(LOCN_ID_SPIDER_NEST, "Spider's Nest", "There are webs everywhere...", 1, 1)
            {
                MonsterHere = IMonster.MonsterID(3)
            };

            ILocation graveyard = new ILocation(LOCN_ID_GRAVEYARD, "Graveyard", "It's always eerie walking through a graveyard in the dark.", 1, -1)
            {
                MonsterHere = IMonster.MonsterID(0)
            };

            ILocation mushroomgrove = new ILocation(LOCN_ID_MUSHROOM_GROVE, "Mushroom Grove", "Countless small mushrooms are growing on trees and underfoot.", 2, 1)
            {
                MonsterHere = IMonster.MonsterID(1),
                ItemHere = new InventoryItem(IItem.ItemID(104), 1)
            };

            ILocation hut = new ILocation(LOCN_ID_ALCHEMIST_HOUSE, "Hut", "There is a sign outside that says \"Fizzlebrew Alchemy\". Blue smoke is coming out of the chimney.", 3, 0)
            {
                NpcHere = INpc.NpcID(0)
            };
            
            LocList.Add(house);
            LocList.Add(forest);
            LocList.Add(deepforest);
            LocList.Add(spidernest);
            LocList.Add(graveyard);
            LocList.Add(hut);
            LocList.Add(mushroomgrove);
        }

        public static ILocation GetLocAt(int x, int y)
        {
            return LocList.FirstOrDefault(l => l.PosX == x && l.PosY == y);
        }
    }
}
