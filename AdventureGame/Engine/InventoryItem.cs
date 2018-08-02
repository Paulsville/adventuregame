using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class InventoryItem
    {
        Item Itm { get; set; }
        int ItmPosition { get; set; }
        int ItmQty { get; set; }

        public InventoryItem(Item itm, int itmPosition, int itmQty)
        {
            Itm = itm;
            ItmPosition = itmPosition;
            ItmQty = ItmQty;
        }
    }
}
