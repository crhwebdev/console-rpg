using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actors
{
    public abstract class Actor
    {        
        public virtual string Name { get; protected set; }
        public virtual Location Location { get; set; }

        //Has various methods that correspond to actions that can be executed with him as the reciever
        public abstract DisplayText Look();
        public abstract DisplayText Say(string text);
        public abstract DisplayText Move(Location location);       
    }
}
