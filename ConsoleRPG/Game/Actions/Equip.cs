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
        ////////////////////////////////////////////////////////////////////////////////////////
        //   CONSTRUCTOR                          
        ////////////////////////////////////////////////////////////////////////////////////////

        public Equip(Actor actor, string target)
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
        /// Executes Equip action on actor 
        /// </summary>
        /// <returns>DisplayText</returns>
        public override DisplayText Do()
        {                                     
            return _actor.Equip(_target); 
        }
        
    }
}
