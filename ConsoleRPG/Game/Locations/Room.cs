using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Locations
{
    public class Room
    {
        public string Description { get; private set; }

        public Room(string description)
        {
            Description = description;
        }

        public DisplayText Enter(Actor actor)
        {
            actor.Location = this;
            return new DisplayText(actor.Name + " enters " + Description);
        }
    }
}
