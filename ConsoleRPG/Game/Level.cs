using ConsoleRPG.Game.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game
{
    public class Level
    {
        public virtual List<Location> Locations { get; set; }
        public virtual Location StartingLocation { get; set; }
        
    }
}
