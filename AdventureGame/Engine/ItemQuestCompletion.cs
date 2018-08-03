using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ItemQuestCompletion : IItem
    {
        IQuest Quest { get; set; }
        int ReqdQty { get; set; }

        public ItemQuestCompletion(int id, string name, string desc, IQuest quest, int reqdQty) : base(id, name, desc)
        {
            Quest = quest;
            ReqdQty = reqdQty;
        }
    }
}
