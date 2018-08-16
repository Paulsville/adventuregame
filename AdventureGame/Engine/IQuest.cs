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
        string QuestName { get; set; }
        string QuestDesc { get; set; }
        int RewardXp { get; set; }
        int RewardGold { get; set; }
        IItem RewardItem { get; set; }
        public IQuestItem ItemToComplete { get; set; }
        public IQuest QuestPreReq { get; set; }

        public IQuest(int id, string questName, string questDesc, int rewardXp, int rewardGold)
        {
            ID = id;
            QuestName = questName;
            QuestDesc = questDesc;
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
