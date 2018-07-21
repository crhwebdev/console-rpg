using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Locations
{
    public abstract class Location : IViewable
    {
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }

        public abstract DisplayText Enter(Actor actor);

        public virtual DisplayText Viewed(Actor viewer)
        {
            return new DisplayText(Description);
        }
    }
}
