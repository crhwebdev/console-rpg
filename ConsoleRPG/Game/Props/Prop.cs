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
        public virtual string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual Location Location { get; set; }

        public Prop(string name)
        {
            Name = name;
        }

        public virtual DisplayText Viewed(Actor viewer)
        {
            throw new NotImplementedException();
        }
    
    }
}
