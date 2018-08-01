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
            return new DisplayText(this.Name + " gets the " + itemTarget.Name);
        }
      
        public override DisplayText Look(IViewable viewedTarget)
        {

            var text = new DisplayText();
            if(viewedTarget is Location)
            {
                text.Add(this.Name + " looks around...");
            }
            else
            {
                text.Add(this.Name + " looks at " + viewedTarget.Name);                
            }
           
            DisplayText viewedTargetText = viewedTarget.Viewed(this);                        
            text.Add(viewedTargetText);

            return text;                                                
        }

        public override DisplayText Move(Location location)
        {

            var moveDisplayText = new DisplayText(this.Name + " moves...");
            moveDisplayText.Add(location.Enter(this));

            return moveDisplayText;
        }

        public override DisplayText Say(string text)
        {
            return new DisplayText(this.Name + " says: '" + text + "'");
        }

     
    }
}
