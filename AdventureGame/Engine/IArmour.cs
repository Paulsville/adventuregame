using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class IArmour : IItem
    {
        int BonusHp { get; set; }

        public IArmour(int id, string name, string desc, int bonusHP) : base(id, name, desc)
        {
            BonusHp = bonusHP;
        }

        public static void EquipArmour(int slotID, IArmour itemToEquip, Player player)
        {
            player.Inventory.Remove(itemToEquip);

            switch(slotID)
            {
                case 0: //head
                    if(player.HeadSlot != null)
                    {
                        player.Inventory.Add(player.HeadSlot);
                    }
                    player.HeadSlot = itemToEquip;
                    break;
                case 1: //chest
                    if (player.ChestSlot != null)
                    {
                        player.Inventory.Add(player.ChestSlot);
                    }
                    player.ChestSlot = itemToEquip;
                    break;
                case 2: //legs
                    if(player.LegSlot != null)
                    {
                        player.Inventory.Add(player.LegSlot);
                    }
                    player.LegSlot = itemToEquip;
                    break;
                case 3: //feet
                    if(player.FootSlot != null)
                    {
                        player.Inventory.Add(player.FootSlot);
                    }
                    player.FootSlot = itemToEquip;
                    break;
                case 4: //hands
                    if(player.HandSlot != null)
                    {
                        player.Inventory.Add(player.HandSlot);
                    }
                    player.HandSlot = itemToEquip;
                    break;
                default:
                    break;
            }
        }
    }
}
