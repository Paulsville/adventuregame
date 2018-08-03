using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class InventoryItem
    {
        IItem Itm { get; set; }
        int ItmPosition { get; set; }
        int ItmQty { get; set; }

        public InventoryItem(IItem itm, int itmPosition, int itmQty)
        {
            Itm = itm;
            ItmPosition = itmPosition;
            ItmQty = ItmQty;
        }
    }
}
