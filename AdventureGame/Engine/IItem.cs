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
        string ItmName { get; set; }
        string ItmDesc { get; set; }

        public IItem(int id, String name, String desc)
        {
            ID = id;
            ItmName = name;
            ItmDesc = desc;
        }
    }
}
