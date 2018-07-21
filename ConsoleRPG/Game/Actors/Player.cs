using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actors
{
    public class Player : Actor
    {       
        //Name property inherieted from Actor
        //Location property inherieted from Actor

        public Player(string name)
        {
            Name = name;
        }

        public override DisplayText Look()
        {
            return new DisplayText(Name + " sees stuff!");
        }

        public DisplayText Look(IViewable viewedTarget)
        {
            return new DisplayText(Name + " looks at " + viewedTarget.Name);
        }

        public override DisplayText Say(string text)
        {
            return new DisplayText(Name + " says, '" + text + "'");
        }

        public override DisplayText Move(Location location)
        {
            var moveDisplayText = new DisplayText(Name + " moves");
            var enterDisplayText = location.Enter(this);            
            moveDisplayText.Add(enterDisplayText);
            return moveDisplayText;
        }
    }
}
