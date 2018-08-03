using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ILocation
    {
        int ID { get; set; }
        string Name { get; set; }
        string Desc { get; set; }
        Npc NpcHere { get; set; }
        Monster MonsterHere { get; set; }

        public ILocation(int id, string name, string desc, Npc npcHere = null, Monster monsterHere = null)
        {
            ID = id;
            Name = name;
            Desc = desc;
            NpcHere = npcHere;
            MonsterHere = monsterHere;
        }

    }
}
