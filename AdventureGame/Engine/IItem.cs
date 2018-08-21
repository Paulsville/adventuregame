using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class IItem
    {
        int ID { get; set; }
        public string ItmName { get; set; }
        public string ItmDesc { get; set; }

        public IItem(int id, String name, String desc)
        {
            ID = id;
            ItmName = name;
            ItmDesc = desc;
        }

        public static IItem ItemID(int id)
        {
            foreach (IItem item in ListItems.ItemList)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
