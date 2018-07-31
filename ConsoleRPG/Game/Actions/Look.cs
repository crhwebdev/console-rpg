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

            var viewedTarget = Util.GetViewableMatchInLocation(_actor.Location, _target);
            if(viewedTarget != null)
            {
                return _actor.Look(viewedTarget);
            }

            return new DisplayText("I don't understand.");
        }
      
    }
}
