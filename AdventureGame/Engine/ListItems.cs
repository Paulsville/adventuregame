using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ListItems
    {
        public static readonly List<IItem> ItemList = new List<IItem>();

        //starting gear
        public const int ITEM_ID_BASIC_SWORD = 0;
        public const int ITEM_ID_BASIC_HAT = 1;
        public const int ITEM_ID_BASIC_SHIRT = 2;
        public const int ITEM_ID_BASIC_LEGGINGS = 3;
        public const int ITEM_ID_BASIC_SHOES = 4;
        public const int ITEM_ID_BASIC_GLOVES = 5;

        //quest items
        public const int ITEM_ID_RAT_TAIL = 6;
        public const int ITEM_ID_WOLF_FUR = 7;
        public const int ITEM_ID_SNAKE_SKIN = 8;
        public const int ITEM_ID_SPIDER_FANGS = 9;

        public static void PopulateItemList()
        {
            ItemList.Add(new IWeapon(ITEM_ID_BASIC_SWORD, "Training Sword", "A simple iron sword.", 0, 0, 3));
            ItemList.Add(new IArmour(ITEM_ID_BASIC_HAT, "Cloth Cap", "A soft cloth hat.", 0));
            ItemList.Add(new IArmour(ITEM_ID_BASIC_SHIRT, "Linen Shirt", "Comfortable, but not very strong.", 0));
            ItemList.Add(new IArmour(ITEM_ID_BASIC_LEGGINGS, "Cloth Leggings", "They're slightly ripped at the bottoms.", 0));
            ItemList.Add(new IArmour(ITEM_ID_BASIC_SHOES, "Sandals", "Worn out from all that running.", 0));
            ItemList.Add(new IArmour(ITEM_ID_BASIC_GLOVES, "Woolly Gloves", "Nice and warm!", 0));

            ItemList.Add(new IItem(ITEM_ID_RAT_TAIL, "Rat Tail", "The tail from a giant rat."));
            ItemList.Add(new IItem(ITEM_ID_WOLF_FUR, "Wolf Fur", "Fur skinned from a wolf."));
            ItemList.Add(new IItem(ITEM_ID_SNAKE_SKIN, "Snake Skin", "Shed from an adder."));
            ItemList.Add(new IItem(ITEM_ID_SPIDER_FANGS, "Spider Fangs", "Pointy and probably venomous."));
        }
    }
}
