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

        public Get(Actor actor, string target)
        {
            _actor = actor;
            _target = target;
        }

        public override DisplayText Do()
        {
            if(_target == "")
            {
                return new DisplayText("You cannot get that!");
            }

            var itemTarget = Util.GetItemMatchInLocation(_actor.Location, _target);

            if (itemTarget != null)
            {
                return _actor.Get(itemTarget);
            }

            return new DisplayText("You cannot get that!");
        }        
    }

   
}
