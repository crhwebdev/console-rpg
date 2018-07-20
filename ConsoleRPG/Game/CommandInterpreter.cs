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

        public CommandInterpreter(GameEngine gameEngine)
        {
            _gameEngine = gameEngine;
            _testRoom = new Room("A dark dank chamber full of soft whisper voices...");
        }

        public IAction Interpret(string commandPhrase, Actor player)
        {
            
            if (commandPhrase == "quit")
            {
                var quit = new Quit(_gameEngine);
                return quit;
            }
            else if (commandPhrase == "look")
            {
                var look = new Look(player);
                return look;                
            }
            else if (commandPhrase == "move")
            {
                var move = new Move(player, _testRoom);
                return move;
            }
            else if (commandPhrase == "say hello")
            {
                var say = new Say(player, "hello");
                return say;                
            }
            else
            {
                var message = new Message("Say what?");
                return message;
            }
        }
    }
}
