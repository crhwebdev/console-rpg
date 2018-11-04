using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Interfaces;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game
{
    public class ActorAI : IActorAI
    {

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PROTECTED CONSTRUCTOR  - Is a Singelton                        
        //////////////////////////////////////////////////////////////////////////////////////// 

        protected ActorAI(){}

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PRIVATE FIELDS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        private static ActorAI _instance = null;        

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        ////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// This method returns either the existing Instance of ActorAI or creates a new one
        /// a reference to the GameEngine must be passed in. 
        /// </summary>
        /// <param name="game">reference to GameEngine</param>
        /// <returns>Instance of CombatManager</returns>
        public static ActorAI Instance()
        {
            if (_instance == null)
            {
                _instance = new ActorAI();
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
