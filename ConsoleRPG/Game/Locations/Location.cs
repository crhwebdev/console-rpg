﻿using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Props;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Locations
{
    public class Location : IViewable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Item> Items { get; set; }

        public Location ExitNorth { get; set; }        
        public Location ExitSouth { get; set; }
        public Location ExitEast { get; set; }
        public Location ExitWest { get; set; }

        public Location(string name)
        {
            Name = name;
            Actors = new List<Actor>();
            Items = new List<Item>();
        }

        public virtual DisplayText Enter(Actor actor)
        {
            //set location of actor entering location
            actor.Location = this;
            
            //get description of location and add to DisplayText to be returned
            DisplayText enterDisplayText;


            if (actor is Player)
            {
                
                enterDisplayText = new DisplayText(actor.GetPersonalPronoun() + " enters " + Description);
            }
            else
            {
                enterDisplayText = new DisplayText("");
            }

            

            //add list of npcs to DisplayText 
            enterDisplayText.Add(GetListOfActorsDisplay());

            //add list of items to DisplayText
            enterDisplayText.Add(GetListOfItemsDisplay());


            return enterDisplayText;
        }

        public virtual DisplayText Viewed(Actor viewer)
        {
            var viewedDisplayText = new DisplayText(viewer.GetPersonalPronoun() + " sees " + Description);

            //get list of npcs in room
            var npcListDisplayText = new DisplayText();
            foreach (var person in Actors)
            {
                var personDisplayTextLine = new DisplayTextLine(person.Name + " is here");
                npcListDisplayText.Add(personDisplayTextLine);
            }
           
            //add list of npcs to DisplayText 
            viewedDisplayText.Add(GetListOfActorsDisplay());

            //add list of items to DisplayText
            viewedDisplayText.Add(GetListOfItemsDisplay());

            return viewedDisplayText;
        }

        private DisplayText GetListOfActorsDisplay()
        {
            //get list of npcs in room
            var npcListDisplayText = new DisplayText();
            foreach (var person in Actors)
            {
                var personDisplayTextLine = new DisplayTextLine(person.Name + " is here");
                npcListDisplayText.Add(personDisplayTextLine);
            }

            return npcListDisplayText;
        }

        private DisplayText GetListOfItemsDisplay()
        {
            //get list of items in room

            var itemListDisplayText = new DisplayText();

            if(Items.Count > 0)
            {
                itemListDisplayText.Add("Items:");
                
            }
            else
            {
                return itemListDisplayText;
            }

            foreach (var item in Items)
            {
                var itemDisplayTextLine = new DisplayTextLine(item.Name);
                itemListDisplayText.Add(itemDisplayTextLine);
            }

            return itemListDisplayText;
        }
        
    }
}
