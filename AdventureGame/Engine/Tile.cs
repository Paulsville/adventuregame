using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Tile
    {
        int ID { get; set; }
        string Name { get; set; }
        bool CanWalk { get; set; }
        
        public Tile(int id, string name, bool canWalk)
        {
            ID = id;
            Name = name;
            CanWalk = canWalk;
        }
    }
}
