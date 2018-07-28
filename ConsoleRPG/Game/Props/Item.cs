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

        public DisplayText Taken()
        {
            throw new NotImplementedException();
        }

        public DisplayText Dropped()
        {
            throw new NotImplementedException();
        }
    }
}
