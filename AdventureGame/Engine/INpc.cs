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
        public string Greetings { get; set; }
        public List<IQuest> GiveQuests { get; set; }

        public INpc(int id, string name)
        {
            ID = id;
            Name = name;
            GiveQuests = new List<IQuest>();
        }

        public static INpc NpcID(int id)
        {
            return ListNpcs.NpcList.FirstOrDefault(n => n.ID == id);
        }
    }
}
