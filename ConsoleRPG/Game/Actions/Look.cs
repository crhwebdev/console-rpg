using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Look : Action
    {
        ////////////////////////////////////////////////////////////////////////////////////////
        //   CONSTRUCTOR                          
        ////////////////////////////////////////////////////////////////////////////////////////

        public Look(Actor actor, string target)
        {
            _actor = actor;
            _target = target;
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
        /// Executes Look action on actor 
        /// </summary>
        /// <returns>DisplayText</returns>
        public override DisplayText Do()
        {
            return _actor.Look(_target);            
        }
      
    }
}
