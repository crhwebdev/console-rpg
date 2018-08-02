using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Props;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Get : Action
    {
        private Actor _actor;
        private string _target;

        public Get(Actor actor, string commandClauseString)
        {
            _actor = actor;
            _target = commandClauseString;
        }

        public override DisplayText Do()
        {
            return _actor.Get(_target);            
        }        
    }

   
}
