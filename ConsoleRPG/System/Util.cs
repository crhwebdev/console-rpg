using ConsoleRPG.Game;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.System
{
    public static class Util
    {
        public static IViewable GetViewableMatchInLocation(Location location, string targetName)
        {

            IViewable viewableMatch = null;

            if (targetName == "")
            {
                viewableMatch = location;
                return viewableMatch;
            }
                                                            
            viewableMatch = GetItemMatchInLocation(location, targetName);
            if (viewableMatch != null)
            {
                return viewableMatch;
            }

            viewableMatch = GetActorMatchInLocation(location, targetName);
            if (viewableMatch != null)
            {
                return viewableMatch;
            }
      
            return null;
        }

        public static Actor GetActorMatchInLocation(Location location, string targetName)
        {
            foreach (var person in location.Actors)
            {
                //if target string equals this persons name, then we have a match
                if (targetName.Equals(person.Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return person as Actor;
                }
            }

            return null;

        }

        public static Item GetItemMatchInLocation(Location location, string targetName)
        {
            
            foreach (var item in location.Items)
            {
                //if target string equals this persons name, then we have a match
                if (targetName.Equals(item.Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return item as Item;
                }
            }

            return null;
        }
    }
}
