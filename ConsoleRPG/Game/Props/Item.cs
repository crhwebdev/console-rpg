using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props
{
    public class Item : Prop
    {

        public Item(string name) : base(name)
        {
            
        }

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
