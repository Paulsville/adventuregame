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
                monster = "You see a " + loc.MonsterHere.Name + ".";
            }
            else
            {
                monster = "There doesn't seem to be any monsters here.";
            }
            return locHeader + "\n\n" + locDesc + "\n\n" + monster;
        }
    }
}
