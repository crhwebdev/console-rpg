using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Props;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Locations
{
    public abstract class Location : IViewable
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual List<Actor> Actors { get; set; }
        public virtual List<IProp> Props { get; set; }

        public virtual DisplayText Enter(Actor actor)
        {
            actor.Location = this;

            return new DisplayText("You enter " + Description);
        }

        public virtual DisplayText Viewed(Actor viewer)
        {
            return new DisplayText("You see " + Description);
        }
    }
}
