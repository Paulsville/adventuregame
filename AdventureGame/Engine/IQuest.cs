using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class IQuest
    {
        public int ID { get; set; }
        public string QuestName { get; set; }
        public string QuestDesc { get; set; }
        public string QuestDialogue { get; set; }
        public string RewardDialogue { get; set; }
        public int RewardXp { get; set; }
        public int RewardGold { get; set; }
        public InventoryItem RewardItem { get; set; }
        public IQuestItem ItemToComplete { get; set; }
        public IQuest QuestPreReq { get; set; }
        public bool Completed { get; set; }

        public IQuest(int id, string questName, int rewardXp, int rewardGold)
        {
            ID = id;
            QuestName = questName;
            RewardXp = rewardXp;
            RewardGold = rewardGold;
            Completed = false;
        }
        public static IQuest QuestID(int id)
        {
            return ListQuests.QuestList.FirstOrDefault(q => q.ID == id);
        }
    }
}
