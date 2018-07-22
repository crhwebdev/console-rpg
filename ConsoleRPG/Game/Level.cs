using ConsoleRPG.Game.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game
{
    public abstract class Level
    {
        public virtual List<Location> Locations { get; set; }
        
    }
}
