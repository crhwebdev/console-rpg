using ConsoleRPG.Game.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actors
{
    public abstract class Actor
    {        
        public virtual string Name { get; protected set; }
        public virtual Room Location { get; set; }

        //Has various methods that correspond to actions that can be executed with him as the reciever
        public abstract string Look();
        public abstract string Say(string text);
        public abstract void Move(Room location);
       
    }
}
