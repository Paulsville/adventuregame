using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ItemArmour : Item
    {
        int SlotID { get; set; }
        int BonusHp { get; set; }
        int BonusMp { get; set; }

        public ItemArmour(int id, string name, string desc, int slotID, int bonusHP, int bonusMP) : base(id, name, desc)
        {
            SlotID = slotID;
            BonusHp = bonusHP;
            BonusMp = bonusMP;
        }
    }
}
