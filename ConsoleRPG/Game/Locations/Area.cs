using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Locations
{
    public class Area : Location
    {
        public override Location ExitNorth { get; set; }
        public override Location ExitSouth { get; set; }
        public override Location ExitEast { get; set; }
        public override Location ExitWest { get; set; }

        public Area(string name) : base(name)
        {
            
        }
    }
}
