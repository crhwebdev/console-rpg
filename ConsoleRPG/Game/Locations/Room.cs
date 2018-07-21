using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Locations
{
    public class Room : Location
    {
        public override string Description { get; set; }

        public Room(string description)
        {
            Description = description;
        }

        public override DisplayText Enter(Actor actor)
        {
            actor.Location = this;
            return new DisplayText(actor.Name + " enters " + Description);
        }
    }
}
