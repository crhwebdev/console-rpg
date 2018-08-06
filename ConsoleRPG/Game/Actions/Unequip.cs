using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Unequip : Action
    {       
        private Actor _actor;
        private string _target;

        //needs access to player (i.e. actor), portal (i.e. reciever), and then other stuff depending on Action
        public Unequip(Actor actor, string target)
        {
            _actor = actor;
            _target = target;
        }

        public override DisplayText Do()
        {                                     
            return _actor.Unequip(_target); 
        }
        
    }
}
