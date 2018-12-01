using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Interfaces;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actors
{
    public class NPCCombatResolver : ICombatResolver
    {

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PROTECTED CONSTRUCTOR  - Is a Singelton                        
        //////////////////////////////////////////////////////////////////////////////////////// 

        protected NPCCombatResolver(){}

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PRIVATE FIELDS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        private static NPCCombatResolver _instance = null;        

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        ////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// This method returns either the existing Instance of ActorAI or creates a new one
        /// a reference to the GameEngine must be passed in. 
        /// </summary>
        /// <param name="game">reference to GameEngine</param>
        /// <returns>Instance of CombatManager</returns>
        public static NPCCombatResolver Instance()
        {
            if (_instance == null)
            {
                _instance = new NPCCombatResolver();
            }

            return _instance;
        }

        public DisplayText DetermineCombatRound(Actor host, Actor target)
        {
            return new DisplayText("DetermineCombatRound called!");

            //checks that target has a location
            //checks that location of host Actor is same as target

        }

        
    }
}
