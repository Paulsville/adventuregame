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
        public string Name { get; set; }
        public List<IQuest> GiveQuest { get; set; }

        public INpc(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
