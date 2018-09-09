using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Quit : Action
    {
        ////////////////////////////////////////////////////////////////////////////////////////
        //   CONSTRUCTOR                          
        ////////////////////////////////////////////////////////////////////////////////////////

        public Quit(GameEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PRIVATE FIELDS                          
        ////////////////////////////////////////////////////////////////////////////////////////

        private GameEngine _gameEngine;

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        /// <summary>
        /// Executes Quit action, which calls 
        ///  Quit method on GameEngine.
        /// </summary>
        /// <returns>DisplayText</returns>
        public override DisplayText Do()
        {
            _gameEngine.Stop();
            return new DisplayText("Quiting game...");
        }       
    }
}
