using ConsoleRPG.Game;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Interfaces;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.System
{
    public static class Util
    {
        
       
             
        public static Location GetExitMatchInLocation(Location location, string destinationName)
        {
            if (destinationName.Equals("north", StringComparison.CurrentCultureIgnoreCase) && location.ExitNorth != null)
            {
                return location.ExitNorth;
            }

            if (destinationName.Equals("south", StringComparison.CurrentCultureIgnoreCase) && location.ExitSouth != null)
            {
                return location.ExitSouth;
            }

            if (destinationName.Equals("east", StringComparison.CurrentCultureIgnoreCase) && location.ExitEast != null)
            {
                return location.ExitEast;
            }

            if (destinationName.Equals("west", StringComparison.CurrentCultureIgnoreCase) && location.ExitWest != null)
            {
                return location.ExitWest;
            }

            return null;
        }

        
    }
}
