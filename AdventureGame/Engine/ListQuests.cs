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
        public const int QUEST_ID_MUSHROOMBOSS = 5;

        public static void PopulateQuestList()
        {
            IQuest RAT_TAILS = new IQuest(QUEST_ID_RATSTAILS, "Rat Catching", 10, 0)
            {
                ItemToComplete = new IQuestItem(IItem.ItemID(100), 5),
                QuestDesc = "Bring the alchemist 5 rat tails.",
                QuestDialogue = "Hello traveller! \n\nI don't have any potions at the moment, but we can make some together! I'm very old though, so you'll have to gather the ingredients for me." +
                "\n\nFirst, I need 5 tails from the giant rats in the graveyard.",
                RewardDialogue = "Excellent, these will do fine."
            };

            IQuest SPIDER_FANGS = new IQuest(QUEST_ID_SPIDERFANGS, "Spider Venom", 10, 0)
            {
                ItemToComplete = new IQuestItem(IItem.ItemID(103), 10),
                QuestDesc = "Bring the alchemist 10 spider fangs.",
                QuestDialogue = "Next I need some spider venom. Don't look at me like that, it's a normal part of a healing potion." +
                "\n\nI'll need 10 fangs - that's 5 pairs. Once I have them I'll extract the venom from inside them.",
                RewardDialogue = "Very nice, I'll start drawing out the venom.",
                QuestPreReq = IQuest.QuestID(0)
            };

            IQuest MUSHROOM_PICKING = new IQuest(QUEST_ID_MUSHROOMS, "Fungus Hunting", 10, 0)
            {
                ItemToComplete = new IQuestItem(IItem.ItemID(104), 3),
                QuestDesc = "Bring the alchemist 3 mushrooms.",
                QuestDialogue = "Now, the last ingredient will be a particular mushroom that grows in the forests around here. I think 3 large ones will do." +
                "Be careful though - last time I sent someone to find some they didn't come back...",
                RewardDialogue = "A giant...mushroom? How odd.",
                QuestPreReq = IQuest.QuestID(3)
            };

            IQuest MUSHROOM_SLAYING = new IQuest(QUEST_ID_MUSHROOMBOSS, "Fungus Hunting, Round 2", 30, 15)
            {
                ItemToComplete = new IQuestItem(IItem.ItemID(105), 1),
                QuestDesc = "Defeat the Mushroom Monster.",
                QuestDialogue = "I think that giant monster shroom must have killed my last apprentice!" +
                "Can you hunt down that monster and kill it? I'll pay you for your trouble, and you can have the potions for free too!",
                RewardDialogue = "\"Horace\"...so he really wasn't just hallucinating when he said a mushroom chased him around. " +
                "As promised, here's your gold and the potions. Thank you, adventurer!",
                QuestPreReq = IQuest.QuestID(4),
                RewardItem = new InventoryItem(IItem.ItemID(201), 5)
            };

            QuestList.Add(RAT_TAILS);
            QuestList.Add(SPIDER_FANGS);
            QuestList.Add(MUSHROOM_PICKING);
            QuestList.Add(MUSHROOM_SLAYING);
        }
    }
}
