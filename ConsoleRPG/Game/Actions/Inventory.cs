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
        
        public Inventory(Actor actor)
        {
            _actor = actor;    
        }

        public override DisplayText Do()
        {
            return _actor.ShowInventory();
        }
    }
}
