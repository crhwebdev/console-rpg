using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Look : Action
    {
        
        private Actor _actor;
        private string _target;
                
        //needs access to player (i.e. actor), portal (i.e. reciever), and then other stuff depending on Action
        public Look(Actor actor, string target)
        {
            _actor = actor;
            _target = target;
        }
        
     
        public override DisplayText Do()
        {

            var viewedTarget = GetViewableObject(_target);
            if(viewedTarget != null)
            {
                return _actor.Look(viewedTarget);
            }

            return new DisplayText("I don't understand.");
        }

        private IViewable GetViewableObject(string target)
        {
            var currentLocation = _actor.Location;

            if (target == "")
            {
                return currentLocation;
            }

           
            //TODO: refactor using Linq maybe
            foreach(var person in currentLocation.Actors)
            {
                //if target string equals this persons name, then we have a match
                if (target.Equals(person.Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return person;
                }
            }


            return null;
        }


    }
}
