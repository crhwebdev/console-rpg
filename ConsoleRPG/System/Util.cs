using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.System
{
    public static class Util
    {
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
