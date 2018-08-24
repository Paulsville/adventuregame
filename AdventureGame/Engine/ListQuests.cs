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
        public const int QUEST_ID_MUSHROOMS = 4;

        public static void PopulateQuestList()
        {
            IQuest RAT_TAILS = new IQuest(QUEST_ID_RATSTAILS, "Rat Catching", 10, 0)
            {
                ItemToComplete = new IQuestItem(IItem.ItemID(6), 5),
                QuestDesc = "I can make you some potions if you want. I'm very old though, so you'll have to gather the ingredients for me." +
                "\n\nFirst, I need 5 tails from the giant rats in the graveyard.",
                RewardDialogue = "Excellent, these will do fine."
            };

            IQuest SPIDER_FANGS = new IQuest(QUEST_ID_SPIDERFANGS, "Spider Venom", 10, 0)
            {
                ItemToComplete = new IQuestItem(IItem.ItemID(9), 10),
                QuestDesc = "Next I need some spider venom. Don't look at me like that, it's a normal part of a healing potion." +
                "\n\nI'll need 10 fangs - that's 5 pairs. Once I have them I'll extract the venom from inside them.",
                RewardDialogue = "Very nice, I'll start drawing out the venom."
            };

            IQuest MUSHROOM_PICKING = new IQuest(QUEST_ID_MUSHROOMS, "Fungus Hunting", 10, 0)
            {
                ItemToComplete = new IQuestItem(IItem.ItemID(6), 5),
                QuestDesc = "Now, the last ingredient will be a particular mushroom that grows in the forests around here. I think 3 large ones will do." +
                "Be careful though - last time I sent someone to find some they didn't come back...",
                RewardDialogue = "A giant...mushroom? How odd. "
            };

            QuestList.Add(RAT_TAILS);
            QuestList.Add(SPIDER_FANGS);

        }
    }
}
