using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Engine
{
    public class Utils
    {

        public static int NumberBetween(int minimumValue, int maximumValue)
        {
            Random _generator = new Random();
            return _generator.Next(minimumValue, maximumValue + 1);
        }

        public static bool CheckForDeath(Player player)
        {
            if(player.HpCur <= 0)
            {
                player.HpCur = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string LocInfoWriter(Player player)
        {
            string locHeader;
            string locDesc;
            string monster;
            ILocation loc = player.PlayerLocation;
            locHeader = "Location: " + loc.Name;
            locDesc = loc.Desc;
            if(loc.MonsterHere != null)
            {
                if(loc.SpawnedMonster.HpCur == 0)
                {
                    monster = "There is a dead " + loc.MonsterHere.Name + " on the ground.";
                }
                else
                {
                    if(loc.SpawnedMonster.HpCur == -1)
                    {
                        if ("aeiouAEIOU".IndexOf(loc.MonsterHere.Name.Substring(0, 1)) >= 0)
                        {
                            monster = "You see an " + loc.MonsterHere.Name + " " + "(0" + "/" + loc.MonsterHere.HpMax + " HP).";
                        }
                        else
                        {
                            monster = "You see a " + loc.MonsterHere.Name + " " + "(0" + "/" + loc.MonsterHere.HpMax + " HP).";
                        }
                    }
                    else
                    {
                        if ("aeiouAEIOU".IndexOf(loc.MonsterHere.Name.Substring(0, 1)) >= 0)
                        {
                            monster = "You see an " + loc.MonsterHere.Name + " " + "(" + loc.SpawnedMonster.HpCur + "/" + loc.MonsterHere.HpMax + " HP).";
                        }
                        else
                        {
                            monster = "You see a " + loc.MonsterHere.Name + " " + "(" + loc.SpawnedMonster.HpCur + "/" + loc.MonsterHere.HpMax + " HP).";
                        }
                    }
                    
                }
                
            }
            else if(loc.BossHere != null)
            {
                if(loc.SpawnedMonster != null)
                {
                    if(loc.SpawnedMonster.HpCur == 0)
                    {
                        monster = "There is a dead " + loc.SpawnedMonster.Name + " on the ground.";
                    }
                    else
                    {
                        monster = "The " + loc.SpawnedMonster.Name + " is attacking you! (" + loc.SpawnedMonster.HpCur + "/" + loc.BossHere.HpMax + " HP)";
                    }
                }
                else
                {
                    monster = "You feel a little uneasy...";
                }

            }
            else
            {
                monster = "There doesn't seem to be any monsters here.";
            }
            return locHeader + "\n\n" + locDesc + "\n\n" + monster;
        }

        public static string DialogueWriter(Player player)
        {
            INpc npc = player.PlayerLocation.NpcHere;
            return "You greet " + npc.Name + ".\n\n\"" + npc.Greetings + "\"";
        }
    }
}
