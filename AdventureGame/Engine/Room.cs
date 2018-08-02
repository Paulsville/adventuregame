using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Room
    {
        int ID { get; set; }
        string Name { get; set; }
        int SizeX { get; set; }
        int SizeY { get; set; }
        List

        public Room(int id, string name, int sizeX, int sizeY)
        {
            ID = id;
            Name = name;
            SizeX = sizeX;
            SizeY = sizeY;
        }
    }
}
