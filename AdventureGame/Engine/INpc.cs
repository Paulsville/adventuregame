using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class INpc
    {
        int ID { get; set; }
        string Name { get; set; }
        IQuest GiveQuest { get; set; }

        public INpc(int id, string name, IQuest giveQuest)
        {
            ID = id;
            Name = name;
            GiveQuest = giveQuest;
        }
    }
}
