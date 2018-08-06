using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Equip : Action
    {       
        private Actor _actor;
        private string _target;

        public Equip(Actor actor, string target)
        {
            _actor = actor;
            _target = target;
        }

        public override DisplayText Do()
        {                                     
            return _actor.Equip(_target); 
        }
        
    }
}
