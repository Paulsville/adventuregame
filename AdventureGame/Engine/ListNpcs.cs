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

        public const int NPC_ID_ALCHEMIST = 0;

        public static void PopulateNpcList()
        {
            INpc alchemist = new INpc(NPC_ID_ALCHEMIST, "Alchemist Fizzlebrew")
            {
                Greetings = "Hello, traveller! I haven't got any potions in stock at the moment.",
                GiveQuests = { IQuest.QuestID(0), IQuest.QuestID(3), IQuest.QuestID(4), IQuest.QuestID(5) }
            };

            NpcList.Add(alchemist);
        }
    }
}
