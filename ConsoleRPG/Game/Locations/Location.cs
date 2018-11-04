using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Interfaces;
using ConsoleRPG.Game.Props;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Locations
{
    public class Location : IViewable
    {

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC CONSTRUCTOR                          
        //////////////////////////////////////////////////////////////////////////////////////// 
        public Location(string name)
        {
            Name = name;
            Actors = new List<Actor>();
            Hostiles = new List<Actor>();
            Items = new List<Item>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC PROPS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Actor> Hostiles { get; set; }
        public List<Item> Items { get; set; }

        public Location ExitNorth { get; set; } 
        public Location ExitNortheast { get; set; }
        public Location ExitEast { get; set; }
        public Location ExitSoutheast { get; set; }
        public Location ExitSouth { get; set; }
        public Location ExitSouthwest { get; set; }
        public Location ExitWest { get; set; }
        public Location ExitNorthwest { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        //////////////////////////////////////////////////////////////////////////////////////// 


        /// <summary>
        /// Returns an object that impliments IViewable from the location that
        /// has the Name property equal to targetName
        /// </summary>
        /// <param name="targetName">A string that matches the object's Name property</param>
        /// <returns>An IViewable object if a match found. Otherwise, returns null</returns>
        public IViewable GetViewableMatchInLocation(string targetName)
        {

            IViewable viewableMatch = null;

            if (targetName == "")
            {
                viewableMatch = this;
                return viewableMatch;
            }

            viewableMatch = GetItemMatchInLocation(targetName);
            if (viewableMatch != null)
            {
                return viewableMatch;
            }

            viewableMatch = GetActorMatchInLocation(targetName);
            if (viewableMatch != null)
            {
                return viewableMatch;
            }

            return null;
        }

        /// <summary>
        /// Returns an Actor ojbect with a Name property that matches targetName
        /// </summary>
        /// <param name="targetName">A string that matches the object's Name property</param>
        /// <returns>An Actor object if a match found. Otherwise, returns null</returns>
        public Actor GetActorMatchInLocation(string targetName)
        {
            foreach (var person in Actors)
            {
                //if target string equals this persons name, then we have a match
                if (targetName.Equals(person.Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return person as Actor;
                }
            }

            return null;

        }

        /// <summary>
        /// Returns an Item ojbect with a Name property that matches targetName
        /// </summary>
        /// <param name="targetName">A string that matches the object's Name property</param>
        /// <returns>An Item object if a match found. Otherwise, returns null</returns>
        public Item GetItemMatchInLocation(string targetName)
        {

            foreach (var item in Items)
            {
                //if target string equals this persons name, then we have a match
                if (targetName.Equals(item.Name, StringComparison.CurrentCultureIgnoreCase) && item is Item)
                {
                    return item as Item;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a Location ojbect that matches destinationName as determined within the method
        /// </summary>
        /// <param name="destinationName">A string that matches the Location as determined in the method</param>
        /// <returns>A Location object if a match found. Otherwise, returns null</returns>
        public Location GetExitMatchInLocation(string destinationName)
        {
            if (destinationName.Equals("north", StringComparison.CurrentCultureIgnoreCase) && ExitNorth != null)
            {
                return ExitNorth;
            }

            if (destinationName.Equals("south", StringComparison.CurrentCultureIgnoreCase) && ExitSouth != null)
            {
                return ExitSouth;
            }

            if (destinationName.Equals("east", StringComparison.CurrentCultureIgnoreCase) && ExitEast != null)
            {
                return ExitEast;
            }

            if (destinationName.Equals("west", StringComparison.CurrentCultureIgnoreCase) && ExitWest != null)
            {
                return ExitWest;
            }

            return null;
        }

        /// <summary>
        /// Returns a DisplayText object with the text description of the Location 
        /// </summary>
        /// <param name="actor">The actor object that is calling this method and to which a DisplayText object is returned</param>
        /// <returns>A DisplayText object</returns>
        public virtual DisplayText Enter(Actor actor)
        {
            //set location of actor entering location
            actor.Location = this;

            //get description of location and add to DisplayText to be returned

            DisplayText enterDisplayText = new DisplayText();


            if (actor is Player)
            {
                enterDisplayText.Add(new DisplayTextLine(Name, ConsoleColor.Red));
                enterDisplayText.Add(TextStringManager.GetGeneralTextString(GeneralTextStrings.ActorEntersLocation, actor, Description));
                                            
                //add list of npcs to DisplayText 
                enterDisplayText += GetListOfActorsDisplay();              

                //add list of items to DisplayText
                enterDisplayText += GetListOfItemsDisplay();                
              
            }
            else
            {
                enterDisplayText = new DisplayText("");
            }
            
            return enterDisplayText;
        }

        /// <summary>
        /// Returns a DisplayText object with the text description of the location
        /// </summary>
        /// <param name="viewer">The actor object that is calling this method and to whcih a DisplayText object is returned</param>
        /// <returns>A DisplayText object</returns>
        public virtual DisplayText Viewed(Actor viewer)
        {
            var viewedDisplayText = new DisplayText();
            viewedDisplayText.Add(TextStringManager.GetGeneralTextString(GeneralTextStrings.ActorViewsLocation, viewer, Description));
                                    
            //add list of npcs to DisplayText 
            viewedDisplayText += GetListOfActorsDisplay();
                                   
            //add list of items to DisplayText
            viewedDisplayText += GetListOfItemsDisplay();

            return viewedDisplayText;
        }


        ////////////////////////////////////////////////////////////////////////////////////////
        //   PRIVATE METHODS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        /// <summary>
        /// Returns a DisplayText object with a list of Actors in the Location
        /// </summary>
        /// <returns>a DisplayText object</returns>
        private DisplayText GetListOfActorsDisplay()
        {
            //get list of npcs in room
            var npcListDisplayText = new DisplayText();

            foreach (var person in Actors)
            {
                //var personDisplayTextLine = new DisplayTextLine(person.Name + " is here");
                //npcListDisplayText.Add(personDisplayTextLine);
                var personDisplayTextLine = new DisplayTextLine(TextStringManager.GetGeneralTextString(GeneralTextStrings.ActorIsHere, person).ToString());
                npcListDisplayText.Add(personDisplayTextLine);
            }

            return npcListDisplayText;
        }

        /// <summary>
        /// Returns a DisplayText object with a list of Items in the Location
        /// </summary>
        /// <returns>a DisplayText object</returns>
        private DisplayText GetListOfItemsDisplay()
        {
            //get list of items in room

            var itemListDisplayText = new DisplayText();
            
            foreach (var item in Items)
            {
                var itemDisplayTextLine = new DisplayTextLine(item.Name + " is here");
                itemListDisplayText.Add(itemDisplayTextLine);
            }
                                    
            return itemListDisplayText;
        }        
    }
}
