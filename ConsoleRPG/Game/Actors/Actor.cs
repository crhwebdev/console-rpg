using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actors
{
    public abstract class Actor : IViewable
    {        
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Location Location { get; set; }
        public virtual List<Item> Inventory { get; set; }

        public Actor(string name)
        {
            Name = name;
        }

        //Has various methods that correspond to actions that can be executed with him as the reciever       
        public abstract DisplayText Get(Item itemTarget);
        public abstract DisplayText Drop(Item itemTarget);
        public abstract DisplayText Look(IViewable viewedTarget);
        public abstract DisplayText Say(string text);
        public abstract DisplayText Move(Location location); 
        
        public virtual DisplayText Viewed(Actor viewer)
        {
            return new DisplayText("You see " + Description);
        }
    }
}
