using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Locations
{
    public class Room : Location
    {      
        public Room(string name) : base(name)
        {            
        }

        public override DisplayText Enter(Actor actor)
        {
            actor.Location = this;
            return new DisplayText(actor.Name + " enters " + Description);
        }

        public override DisplayText Viewed(Actor viewer)
        {
            return new DisplayText(Description);
        }
    }
}
