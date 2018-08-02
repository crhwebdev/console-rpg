using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Drop : Action
    {
        private Actor _actor;
        private string _target;

        public Drop(Actor actor, string commandClauseString)
        {
            _actor = actor;
            _target = commandClauseString;
        }

        public override DisplayText Do()
        {
            return _actor.Drop(_target);
        }

    }

   
}
