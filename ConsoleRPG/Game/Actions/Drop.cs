﻿using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Drop : Action
    {
        ////////////////////////////////////////////////////////////////////////////////////////
        //   CONSTRUCTOR                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        
        public Drop(Actor actor, string commandClauseString)
        {
            _actor = actor;
            _target = commandClauseString;
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PRIVATE FIELDS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        private Actor _actor;
        private string _target;


        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        /// <summary>
        /// Executes Action on actor that Action was created with
        /// </summary>
        /// <returns></returns>
        public override DisplayText Do()
        {
            return _actor.Drop(_target);
        }

    }

   
}
