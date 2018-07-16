using ConsoleRPG.Game.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actors
{
    class Player : Actor
    {       
        //Name property inherieted from Actor
        //Location property inherieted from Actor

        public Player(string name)
        {
            Name = name;
        }

        public override string Look()
        {
            return Name + " sees stuff!";
        }

        public override void Move(Room location)
        {
            Location = location;
        }
    }
}
