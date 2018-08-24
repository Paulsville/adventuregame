using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class IQuest
    {
        int ID { get; set; }
        public string QuestName { get; set; }
        public string QuestDesc { get; set; }
        public string RewardDialogue { get; set; }
        public int RewardXp { get; set; }
        public int RewardGold { get; set; }
        public InventoryItem RewardItem { get; set; }
        public IQuestItem ItemToComplete { get; set; }
        public IQuest QuestPreReq { get; set; }

        public IQuest(int id, string questName, int rewardXp, int rewardGold)
        {
            ID = id;
            QuestName = questName;
            RewardXp = rewardXp;
            RewardGold = rewardGold;
        }
        public static IQuest QuestID(int id)
        {
            foreach (IQuest quest in ListQuests.QuestList)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        

    }
}
