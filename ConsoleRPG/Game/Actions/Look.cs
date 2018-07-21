using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Look : IAction
    {
        
        private Actor _actor;
        private string _target;
        
        //needs access to player (i.e. actor), portal (i.e. reciever), and then other stuff depending on Action
        public Look(Actor actor, string target)
        {
            _actor = actor;
            _target = target;
        }
        
        public DisplayText Do()
        {
            var currentLocation = _actor.Location;
            return _actor.Look(); 
        }


    }
}
