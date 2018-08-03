﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LootItem
    {
        IItem Item { get; set; }
        int Chance { get; set; }
        int QtyMin { get; set; }
        int QtyMax { get; set; }

        public LootItem(IItem item, int chance, int qtyMin, int qtyMax)
        {
            Item = item;
            Chance = chance;
            QtyMin = qtyMin;
            QtyMax = qtyMax;
        }
    }
}
