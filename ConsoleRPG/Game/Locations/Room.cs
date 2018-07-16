using ConsoleRPG.Game.Actors;
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

        public string Enter(Actor actor)
        {
            return actor.Name + " enters " + Description;
        }
    }
}
