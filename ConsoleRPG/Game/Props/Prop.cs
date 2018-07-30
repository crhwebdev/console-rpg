using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;

namespace ConsoleRPG.Game.Props
{
    public abstract class Prop : IViewable
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Location Location { get; set; }

        public Prop(string name)
        {
            Name = name;
        }

        public virtual DisplayText Viewed(Actor viewer)
        {
            return new DisplayText(Description);
        }
            
    }
}
