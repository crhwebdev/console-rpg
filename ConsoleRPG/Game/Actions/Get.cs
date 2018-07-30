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
                return new DisplayText("You cannot get that");
            }

            var itemTarget = GetItemTarget(_target);

            if (itemTarget != null)
            {
                return _actor.Get(itemTarget);
            }

            return new DisplayText("You cannot get that");
        }

        private Item GetItemTarget(string target)
        {
            var currentLocation = _actor.Location;

            foreach (var item in currentLocation.Props)
            {
                //if target string equals this persons name, then we have a match
                if (target.Equals(item.Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return item as Item;
                }
            }


            return null;
        }
      
    }

   
}
