using ConsoleRPG.Game.Props.Interfaces;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Props
{
    public class Item : Prop, IPortable
    {

        public Item(string name) : base(name){}

        public double Value { get; set; }
        public double Weight { get; set; }

        
    }
}
