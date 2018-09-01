using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class IItem
    {
        public int ID { get; set; }
        public string ItmName { get; set; }
        public string ItmDesc { get; set; }
        public bool IsConsumable { get; set; }

        public IItem(int id, string name, string desc, bool isConsumable = false)
        {
            ID = id;
            ItmName = name;
            ItmDesc = desc;
            IsConsumable = isConsumable;
        }

        public static IItem ItemID(int id)
        {
            return ListItems.ItemList.FirstOrDefault(i => i.ID == id);
        }
    }
}
