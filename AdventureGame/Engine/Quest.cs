using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        int ID { get; set; }
        int RewardXp { get; set; }
        int RewardGold { get; set; }
        Item RewardItem { get; set; }

        public Quest(int id, int rewardXp, int rewardGold, Item rewardItem)
        {
            ID = id;
            RewardXp = rewardXp;
            RewardGold = rewardGold;
            RewardItem = rewardItem;
        }
    }
}
