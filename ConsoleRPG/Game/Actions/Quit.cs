using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Quit : Action
    {       
        private GameEngine _gameEngine;

        public Quit(GameEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

        public override DisplayText Do()
        {
            _gameEngine.Stop();
            return new DisplayText("Quiting game...");
        }       
    }
}
