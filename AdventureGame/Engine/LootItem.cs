using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LootItem
    {
        public IItem Item { get; set; }
        public int Chance { get; set; }
        public int QtyMin { get; set; }
        public int QtyMax { get; set; }

        public LootItem(IItem item, int chance, int qtyMin, int qtyMax)
        {
            Item = item;
            Chance = chance;
            QtyMin = qtyMin;
            QtyMax = qtyMax;
        }
    }
}
