using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ILocation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string SearchText { get; set; }
        public INpc NpcHere { get; set; }
        public IMonster MonsterHere { get; set; }
        public IMonster BossHere { get; set; }
        public Monster SpawnedMonster { get; set; }
        public IItem ItemHere { get; set; }
        public IQuest QuestReqToSearch { get; set; }
        public string AfterSearchText { get; set; }
        public IItem ItemToEnter { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public bool Discovered { get; set; }
        public bool Revealed { get; set; }
        
        public ILocation(int id, string name, string desc, int posX, int posY)
        {
            ID = id;
            Name = name;
            Desc = desc;
            Discovered = false;
            Revealed = false;
            PosX = posX;
            PosY = posY;
        }

        public static ILocation LocationID(int id)
        {
            return ListLocations.LocList.FirstOrDefault(i => i.ID == id);
        }
    }
}
