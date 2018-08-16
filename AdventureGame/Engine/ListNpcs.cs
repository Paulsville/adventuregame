using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ListNpcs
    {
        public static readonly List<INpc> NpcList = new List<INpc>();

        public const int NPC_ID_HERMIT = 0;

        public static void PopulateNpcList()
        {
            INpc hermit = new INpc(NPC_ID_HERMIT, "Hermit", IQuest.QuestID(0));

            NpcList.Add(hermit);
        }
    }
}
