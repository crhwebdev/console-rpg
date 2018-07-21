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
        private Dictionary<string, string> _prepositions = new Dictionary<string, string>
        {
            {"at", "at" },
            {"to", "to" },
            {"in", "in" }
        };

        public CommandInterpreter(GameEngine gameEngine)
        {
            _gameEngine = gameEngine;
            _testRoom = new Room("A dark dank chamber full of soft whisper voices...");
        }

        public IAction Interpret(string commandPhrase, Actor player)
        {

            //check if commandPhrase is empty and dispatch appropriate message if it is
            if (string.IsNullOrEmpty(commandPhrase.Trim()))
            {
                return new Message("You must enter a command!");
            }

            string[] commandWords = commandPhrase.Split(' ');

            //get first command and set it to action
            string commandAction = commandWords[0];
            string target = "";

            if(commandWords.Length >= 2)
            {
                //there may be a preposition in the second postion. If there is, add it to commandAction
                if (_prepositions.ContainsKey(commandWords[1]))
                {
                    commandAction += " " + commandWords[1];

                    //return rest of commandWords as string - But of course the string.Join complains if beginning index and end index are the same
                    // so we have to do this clunky check
                    try
                    {
                        target = string.Join(" ", commandWords, 2, commandWords.Length - 1);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        target = commandWords[2].ToString();
                    }                                                                                          
                }
                else
                {
                    try
                    {
                        target = string.Join(" ", commandWords, 1, commandWords.Length - 1);                        
                    }
                    catch(ArgumentOutOfRangeException)
                    {
                        target = commandWords[1].ToString();
                    }                    
                }
            }
            
            switch (commandAction)
            {
                case "look":
                case "look at":     
                    return new Look(player, target);
                case "move":
                    return new Move(player, _testRoom);
                case "quit":
                    return new Quit(_gameEngine);
                case "say":
                    return new Say(player, target);
                default:
                    return new Message("Say what?");
            }
                                    
        }
        
      
    }
}
