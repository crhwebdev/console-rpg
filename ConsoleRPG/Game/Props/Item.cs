using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props
{
    public abstract class Item : Prop
    {

        public Item(string name) : base(name){}

        public double Value { get; set; }
        public double Weight { get; set; }

        public virtual DisplayText Taken()
        {
            throw new NotImplementedException();
        }

        public virtual DisplayText Dropped()
        {
            throw new NotImplementedException();
        }
    }
}
