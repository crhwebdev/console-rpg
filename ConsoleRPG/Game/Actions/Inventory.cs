using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Inventory : Action
    {
        private Actor _actor;
        private string _target;

        public Inventory(Actor actor, string target)
        {
            _actor = actor;
            _target = target;
        }

        public override DisplayText Do()
        {
            return _actor.ShowInventory(_target);
        }
    }
}
