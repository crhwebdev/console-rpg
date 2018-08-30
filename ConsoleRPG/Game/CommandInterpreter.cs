using ConsoleRPG.Game.Actions;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
using ConsoleRPG.UI;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleRPG.Game
{
    public class CommandInterpreter
    {
        ////////////////////////////////////////////////////////////////////////////////////////
        //   PROTECTED CONSTRUCTOR  - Is a Singelton                        
        //////////////////////////////////////////////////////////////////////////////////////// 

        protected CommandInterpreter(GameEngine gameEngine)
        {
            _gameEngine = gameEngine;            
        }


        ////////////////////////////////////////////////////////////////////////////////////////
        //   PRIVATE FIELDS                          
        //////////////////////////////////////////////////////////////////////////////////////// 

        private static CommandInterpreter _instance = null;
        private GameEngine _gameEngine;
        private Dictionary<string, string> _prepositions = new Dictionary<string, string>
        {
            {"at", "at" },
            {"to", "to" },
            {"in", "in" }
        };


        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        ////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Get an instance of the CommandInterpreter if it already exists
        /// or create a new one if it dosen't
        /// </summary>
        /// <param name="gameEngine">An instance of the gameEngine used with CommandInterpreter</param>
        /// <returns>Instance of CommandInterpretere</returns>
        public static CommandInterpreter Instance(GameEngine gameEngine)
        {
            if(_instance == null)
            {
                _instance = new CommandInterpreter(gameEngine);
            }

            return _instance;
        }

        /// <summary>
        /// Return a string array of parsed commands
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        public string[] ParseCommandString(string commandString)
        {
            string[] parsedCommandList = new string[2];
            //check if commandPhrase is empty and dispatch appropriate message if it is
            if (string.IsNullOrEmpty(commandString.Trim()))
            {
                return null;
            }

            
            string[] commandWords = commandString.Split(' ');

            //get first command and set it to action
            string commandAction = commandWords[0].ToLower();
            string commandClauseString = "";

            if (commandWords.Length >= 2)
            {
                var preposition = commandWords[1].ToLower();
                //there may be a preposition in the second postion. If there is, add it to commandAction
                if (_prepositions.ContainsKey(preposition))
                {
                    commandAction += " " + preposition;

                    //return rest of commandWords as string - But of course the string.Join complains if beginning index and end index are the same
                    // so we have to do this clunky check
                    if(commandWords.Length >= 3)
                    {                        
                        commandClauseString = string.Join(" ", commandWords, 2, commandWords.Length - 2);                     
                    }
                    
                }
                else
                {                    
                    commandClauseString = string.Join(" ", commandWords, 1, commandWords.Length - 1);                    
                }               
            }

            parsedCommandList[0] = commandAction;
            parsedCommandList[1] = commandClauseString;

            return parsedCommandList;
        }

        /// <summary>
        /// Returns an action for a correct commandList from GameEngine
        /// If not correct, returns a Message Action with error message.
        /// </summary>
        /// <param name="commandList"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public Action GetAction(string[] commandList, Actor player)
        {

            if(commandList == null)
            {
                return new Message("You must enter a command!");
            }

            var action = commandList[0];
            var commandClauseString = commandList[1];
                        
            switch (action)
            {
                case "drop":
                    return new Drop(player, commandClauseString);
                case "equip":
                    return new Equip(player, commandClauseString);
                case "get":
                    return new Get(player, commandClauseString);
                case "inventory":
                    return new Inventory(player);
                case "look":
                case "look at":    
                    return new Look(player, commandClauseString);
                case "move":
                    return new Move(player, commandClauseString);                    
                case "quit":
                    return new Quit(_gameEngine);
                case "say":
                    return new Say(player, commandClauseString);
                case "unequip":
                    return new Unequip(player, commandClauseString);
                default:
                    return new Message("Say what?");
            }                                    
        }                 
    }
}
