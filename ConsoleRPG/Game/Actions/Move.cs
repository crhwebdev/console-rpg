using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Move : IAction
    {       
        private Actor _actor;
        private Location _target;

        //needs access to player (i.e. actor), portal (i.e. reciever), and then other stuff depending on Action
        public Move(Actor actor, Location target)
        {
            _actor = actor;
            _target = target;
        }

        public DisplayText Do()
        {
                    
            var moveDisplayText = _actor.Move(_target);            
            return moveDisplayText;            
        }
    }
}
