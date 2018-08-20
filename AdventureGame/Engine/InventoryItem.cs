using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class InventoryItem
    {
        public IItem Itm { get; set; }
        public int ItmQty { get; set; }

        public InventoryItem(IItem itm, int itmQty)
        {
            Itm = itm;
            ItmQty = itmQty;
        }
    }
}
