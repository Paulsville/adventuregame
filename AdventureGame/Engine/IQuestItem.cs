using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class IQuestItem
    {
        public IItem Item { get; set; }
        IQuest Quest { get; set; }
        public int ReqdQty { get; set; }

        public IQuestItem(IItem item, int reqdQty)
        {
            Item = item;
            ReqdQty = reqdQty;
        }
    }
}
