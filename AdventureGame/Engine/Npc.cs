using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Npc : Creature
    {
        int ID { get; set; }
        string Name { get; set; }

        public Npc(int id, int hpMax, int hpCur, string name) : base(hpMax, hpCur)
        {
            ID = id;
            Name = name;
        }
    }
}
