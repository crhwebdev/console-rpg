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
                
        public Look(Actor actor, string target)
        {
            _actor = actor;
            _target = target;
        }
        
        public override DisplayText Do()
        {
            return _actor.Look(_target);            
        }
      
    }
}
