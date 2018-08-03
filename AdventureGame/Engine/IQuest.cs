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
        int RewardXp { get; set; }
        int RewardGold { get; set; }
        IItem RewardItem { get; set; }

        public IQuest(int id, int rewardXp, int rewardGold, IItem rewardItem)
        {
            ID = id;
            RewardXp = rewardXp;
            RewardGold = rewardGold;
            RewardItem = rewardItem;
        }
    }
}
