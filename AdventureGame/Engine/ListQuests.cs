using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ListQuests
    {
        public static readonly List<IQuest> QuestList = new List<IQuest>();

        public const int QUEST_ID_RATSTAILS = 0;
        public const int QUEST_ID_WOLFSFURS = 1;
        public const int QUEST_ID_SNAKESKINS = 2;
        public const int QUEST_ID_SPIDERFANGS = 3;

        public static void PopulateQuestList()
        {
            IQuest RAT_CATCHING = new IQuest(QUEST_ID_RATSTAILS, "Rat Catching", "The hermit needs you to kill 5 rats in the graveyard and bring back their tails", 50, 5)
            {
                ItemToComplete = new IQuestItem(IItem.ItemID(6), 5)
            };

            
        }
    }
}
