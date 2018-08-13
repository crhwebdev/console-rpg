using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Interfaces
{
    public interface IViewable
    {
        string Name { get; set; } 
        string Description { get; set; }

        DisplayText Viewed(Actor viewer);     
    }
}
