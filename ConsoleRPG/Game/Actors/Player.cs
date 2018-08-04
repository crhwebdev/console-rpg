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

        public override DisplayText Drop(string commandClauseString)
        {
            var displayText = new DisplayText();

            if (commandClauseString == "")
            {
                return new DisplayText("There is nothing to drop!");
            }

            var item = Util.GetItemMatchInInventory(this, commandClauseString);

            if (item != null)
            {
                Location.Items.Add(item);
                item.Location = Location;
                Inventory.Remove(item);
                
                displayText.Add(Name + " drops the " + item.Name);
                return displayText;
            }

            return new DisplayText("You don't have that item!");
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
                Inventory.Add(item);
                item.Location = null;
                Location.Items.Remove(item);                
                displayText.Add(Name + " gets the " + item.Name);
                return displayText;
            }

            return new DisplayText("You cannot get that!");            
        }
      
        public override DisplayText Look(string commandClauseString)
        {
            var displayText = new DisplayText();

            var viewed = Util.GetViewableMatchInLocation(Location, commandClauseString);

            if (viewed == null)
            {
                return new DisplayText("I don't understand.");
                
            }
            
            if (viewed is Location)
            {
                displayText.Add(Name + " looks around...");
            }
            else
            {
                displayText.Add(Name + " looks at " + viewed.Name);
            }

            displayText.Add(viewed.Viewed(this));

            return displayText;                                                
        }

        public override DisplayText Move(string commandClauseString)
        {
            var displayText = new DisplayText();

            if(commandClauseString == "")
            {
                return new DisplayText(Name + " cannot move there!");
            }

            var destination = Util.GetExitMatchInLocation(this.Location, commandClauseString);

            if (destination == null)
            {
                return new DisplayText(Name + " cannot move there!");
            }

            displayText.Add(Name + " moves...");            
            displayText.Add(destination.Enter(this));

            return displayText;
        }

        public override DisplayText Say(string commandClauseString)
        {
            return new DisplayText(Name + " says: '" + commandClauseString + "'");
        }

        public override DisplayText ShowInventory()
        {
            var inventoryDisplayText = new DisplayText();
            var inventoryDisplayTextLine = new DisplayTextLine();  

            if(Inventory.Count < 1)
            {
                inventoryDisplayTextLine.Add("You have nothing in your pack, Master.");
            }
            else if(Inventory.Count == 1)
            {
                inventoryDisplayTextLine.Add("Master, you have: " + Inventory[0].Name + ".");
            }
            else
            {
                inventoryDisplayTextLine.Add("Your Inventory, Master: ");

                var index = 0;

                foreach (var item in Inventory)
                {
                    if (index == Inventory.Count - 1)
                    {
                        inventoryDisplayTextLine.Add(item.Name + ".");
                    }
                    else
                    {
                        inventoryDisplayTextLine.Add(item.Name + ", ");
                    }

                    index++;
                }
            }

            inventoryDisplayText.Add(inventoryDisplayTextLine);

            return inventoryDisplayText;
        }
     
    }
}
