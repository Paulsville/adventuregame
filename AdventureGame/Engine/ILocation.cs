﻿using System;
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
        public INpc NpcHere { get; set; }
        public IMonster MonsterHere { get; set; }
        public IItem ItemToEnter { get; set; }
        public ILocation LocToNorth { get; set; }
        public ILocation LocToEast { get; set; }
        public ILocation LocToSouth { get; set; }
        public ILocation LocToWest { get; set; }

        public ILocation(int id, string name, string desc, INpc npcHere = null, IMonster monsterHere = null)
        {
            ID = id;
            Name = name;
            Desc = desc;
            NpcHere = npcHere;
            MonsterHere = monsterHere;
        }

        public static ILocation LocationID(int id)
        {
            foreach (ILocation locn in ListLocations.LocList)
            {
                if (locn.ID == id)
                {
                    return locn;
                }
            }

            return null;
        }
    }
}