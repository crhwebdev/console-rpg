using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
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
        public override Location Location { get; set; }

        public Player(string name) : base(name)
        {            

        }

        public override DisplayText Drop(Item itemTarget)
        {
            throw new NotImplementedException();
        }

        public override DisplayText Get(Item itemTarget)
        {
            return new DisplayText("You get the " + itemTarget.Name);
        }
      
        public override DisplayText Look(IViewable viewedTarget)
        {
            DisplayText text = new DisplayText();
            DisplayText viewedTargetText = viewedTarget.Viewed(this);                        
            text.Add(viewedTargetText);

            return text;                                                
        }

        public override DisplayText Move(Location location)
        {
            var moveDisplayText = location.Enter(this);
            return moveDisplayText;
        }

        public override DisplayText Say(string text)
        {
            return new DisplayText("You say: '" + text + "'");
        }

     
    }
}
