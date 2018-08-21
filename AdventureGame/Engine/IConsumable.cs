using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class IConsumable : IItem
    {
        public int HpRestore { get; set; }

        public IConsumable(int id, string name, string desc, int hpRestore) : base(id, name, desc, true)
        {
            HpRestore = hpRestore;
        }
    }
}
