﻿using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Look : IAction
    {
        public string Display { get; set; }
        private Actor _actor;

        //needs access to player (i.e. actor), portal (i.e. reciever), and then other stuff depending on Action
        public Look(Actor actor)
        {
            _actor = actor;
        }

        public void Do()
        {
            Display = _actor.Look(); 
        }
    }
}
