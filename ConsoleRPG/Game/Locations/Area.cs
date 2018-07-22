using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Locations
{
    public class Area : Location
    {
        public Location ExitNorth { get; set; }
        public Location ExitSouth { get; set; }
        public Location ExitEast { get; set; }
        public Location ExitWest { get; set; }

        public Area(string name)
        {
            Name = name;
        }
    }
}
