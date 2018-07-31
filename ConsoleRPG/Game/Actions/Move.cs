using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Move : Action
    {       
        private Actor _actor;
        private string _target;

        //needs access to player (i.e. actor), portal (i.e. reciever), and then other stuff depending on Action
        public Move(Actor actor, string target)
        {
            _actor = actor;
            _target = target;
        }

        public override DisplayText Do()
        {
            var destination = Util.GetExitMatchInLocation(_actor.Location, _target);    
            if(destination == null)
            {
                return new DisplayText("You cannot move there!");
            }            
            var moveDisplayText = _actor.Move(destination);            
            return moveDisplayText;            
        }

        
    }
}
