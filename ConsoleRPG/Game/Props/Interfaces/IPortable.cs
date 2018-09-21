using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props.Interfaces
{
    /// <summary>
    /// An interface for game objects that can be aquired by Actors.
    /// </summary>
    public interface IPortable
    {
        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC PROPS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        double Value { get; set; }
        double Weight { get; set; }
               
    }
}
