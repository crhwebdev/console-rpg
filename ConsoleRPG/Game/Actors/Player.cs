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
        

        //for testing purposes 
        public override Location Location { get; set; } = new Room("The Chamber", "A dark dank chamber full of soft whispering voices...");

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
            DisplayText text = new DisplayText();
            DisplayText viewedTargetText = viewedTarget.Viewed(this);

            text.Add(new DisplayText(Name + " looks at " + viewedTarget.Name));            
            text.Add(viewedTargetText);

            return text;                                                
        }

        public override DisplayText Say(string text)
        {
            return new DisplayText(Name + " says, '" + text + "'");
        }

        public override DisplayText Move(Location location)
        {
            var moveDisplayText = new DisplayText(Name + " moves");
            var enterDisplayText = Location.Enter(this);            
            moveDisplayText.Add(enterDisplayText);
            return moveDisplayText;
        }
    }
}
