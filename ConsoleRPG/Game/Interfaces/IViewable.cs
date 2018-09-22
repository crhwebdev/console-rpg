using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Interfaces
{
    /// <summary>
    /// Interface for any game object that is viewable by an actor
    /// </summary>
    public interface IViewable
    {
        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC PROPS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        string Name { get; set; } 
        string Description { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        ////////////////////////////////////////////////////////////////////////////////////////

        DisplayText Viewed(Actor viewer);     
    }
}
