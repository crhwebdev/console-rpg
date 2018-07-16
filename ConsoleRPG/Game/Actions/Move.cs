using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Move : IAction
    {
        public string Display { get; set; }
        private Actor _actor;
        private Room _target;

        //needs access to player (i.e. actor), portal (i.e. reciever), and then other stuff depending on Action
        public Move(Actor actor, Room target)
        {
            _actor = actor;
            _target = target;
        }

        public void Do()
        {            
            _actor.Location = _target;            
            Display = _target.Enter(_actor);            
        }
    }
}
