using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ItemConsumable : IItem
    {
        int HpRestore { get; set; }
        int MpRestore { get; set; }

        public ItemConsumable(int id, string name, string desc, int hpRestore, int mpRestore) : base(id, name, desc)
        {
            HpRestore = hpRestore;
            MpRestore = mpRestore;
        }
    }
}
