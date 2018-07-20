using ConsoleRPG.Game.Actions;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
using ConsoleRPG.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game
{
    public class CommandInterpreter
    {
        private Room _testRoom;  
        private GameEngine _gameEngine;
        private TextConsole _gameConsole;

        public CommandInterpreter(GameEngine gameEngine)
        {
            _gameEngine = gameEngine;
            _gameConsole = gameEngine.GameConsole;
            _testRoom = new Room("A dark dank chamber full of soft whisper voices...");
        }

        public void Interpret(string commandPhrase, Actor player)
        {
            
            if (commandPhrase == "quit")
            {
                var quit = new Quit(_gameEngine);
                _gameConsole.WriteDisplayText(quit.Do());
            }
            else if (commandPhrase == "look")
            {
                var look = new Look(player);

                _gameConsole.WriteDisplayText(look.Do());
            }
            else if (commandPhrase == "move")
            {
                var move = new Move(player, _testRoom);
                _gameConsole.WriteDisplayText(move.Do());
            }
            else if (commandPhrase == "say hello")
            {
                var say = new Say(player, "hello");

                _gameConsole.WriteDisplayText(say.Do());
            }
            else
            {
                _gameConsole.WriteDisplayTextLine(new DisplayTextLine("Say what?"));
            }
        }
    }
}
