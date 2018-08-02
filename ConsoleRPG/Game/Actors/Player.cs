﻿using ConsoleRPG.Game.Locations;
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

        public override DisplayText Drop(string commandClauseString)
        {
            throw new NotImplementedException();
        }

        public override DisplayText Get(string commandClauseString)
        {

            var displayText = new DisplayText();

            if (commandClauseString == "")
            {
                return new DisplayText("There is nothing to get!");
            }

            var item = Util.GetItemMatchInLocation(this.Location, commandClauseString);

            if (item != null)
            {
                displayText.Add(this.Name + " gets the " + item.Name);
                return displayText;
            }

            return new DisplayText("You cannot get that!");            
        }
      
        public override DisplayText Look(string commandClauseString)
        {
            var displayText = new DisplayText();

            var viewed = Util.GetViewableMatchInLocation(this.Location, commandClauseString);

            if (viewed == null)
            {
                return new DisplayText("I don't understand.");
                
            }
            
            if (viewed is Location)
            {
                displayText.Add(this.Name + " looks around...");
            }
            else
            {
                displayText.Add(this.Name + " looks at " + viewed.Name);
            }

            displayText.Add(viewed.Viewed(this));

            return displayText;                                                
        }

        public override DisplayText Move(string commandClauseString)
        {
            var displayText = new DisplayText();

            var destination = Util.GetExitMatchInLocation(this.Location, commandClauseString);

            if (destination == null)
            {
                return new DisplayText(this.Name + " cannot move there!");
            }

            displayText.Add(this.Name + " moves...");
            displayText.Add(this.Location.Enter(this));

            return displayText;
        }

        public override DisplayText Say(string commandClauseString)
        {
            return new DisplayText(this.Name + " says: '" + commandClauseString + "'");
        }
     
    }
}
