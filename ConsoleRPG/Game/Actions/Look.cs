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
            
            return _actor.Look(GetViewableObject()); 
        }

        private IViewable GetViewableObject()
        {
            if(_target == "")
            {
                return _actor.Location;
            }

            //TODO: need to impliment algorithim to search through Locations Actors and Props lists (not implimented yet) for a match with target
            // this search could potentially be added to utility class or we could change IAction to an abstract class and impliment a protected method
            // that does the search.  Probably use LINQ
            return _actor.Location;
        }


    }
}
