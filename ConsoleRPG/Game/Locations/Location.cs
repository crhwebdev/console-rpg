using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Props;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Locations
{
    public abstract class Location : IViewable
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual List<Actor> Actors { get; set; }
        public virtual List<Prop> Props { get; set; }

        public virtual Location ExitNorth { get; set; }
        public virtual Location ExitSouth { get; set; }
        public virtual Location ExitEast { get; set; }
        public virtual Location ExitWest { get; set; }

   
        public virtual DisplayText Enter(Actor actor)
        {
            //set location of actor entering location
            actor.Location = this;

            //get description of location and add to DisplayText to be returned
            var enterDisplayText = new DisplayText("You enter " + Description);

            //get list of npcs in room
            var npcListDisplayText = new DisplayText();
            foreach(var person in Actors)
            {
                var personDisplayTextLine = new DisplayTextLine(person.Name + " is here");
                npcListDisplayText.Add(personDisplayTextLine);
            }

            //add list of npcs to DisplayText 
            enterDisplayText.Add(npcListDisplayText);

            return enterDisplayText;
        }

        public virtual DisplayText Viewed(Actor viewer)
        {
            var viewedDisplayText = new DisplayText("You see " + Description);

            //get list of npcs in room
            var npcListDisplayText = new DisplayText();
            foreach (var person in Actors)
            {
                var personDisplayTextLine = new DisplayTextLine(person.Name + " is here");
                npcListDisplayText.Add(personDisplayTextLine);
            }

            viewedDisplayText.Add(npcListDisplayText);

            return viewedDisplayText;
        }

        
    }
}
