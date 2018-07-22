using ConsoleRPG.Game.Actions;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
using ConsoleRPG.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            //_testRoom = new Room("A dark dank chamber full of soft whispering voices...");
        }

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
            string target = "";

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
                        target = string.Join(" ", commandWords, 2, commandWords.Length - 2);                     
                    }
                    
                }
                else
                {                    
                    target = string.Join(" ", commandWords, 1, commandWords.Length - 1);                    
                }               
            }

            parsedCommandList[0] = commandAction;
            parsedCommandList[1] = target;

            return parsedCommandList;
        }

        public IAction GetAction(string[] commandList, Actor player)
        {

            if(commandList == null)
            {
                return new Message("You must enter a command!");
            }

            var action = commandList[0];
            var target = commandList[1];
                        
            switch (action)
            {
                case "look":
                case "look at":     
                    return new Look(player, target);
                case "move":
                    if(target == "north" && player.Location.ExitNorth != null)
                    {
                        return new Move(player, player.Location.ExitNorth);
                    }

                    if(target == "south" && player.Location.ExitSouth != null)
                    {
                        return new Move(player, player.Location.ExitSouth);
                    }

                    if (target == "east" && player.Location.ExitEast != null)
                    {
                        return new Move(player, player.Location.ExitEast);
                    }

                    if (target == "west" && player.Location.ExitWest != null)
                    {
                        return new Move(player, player.Location.ExitWest);
                    }
                    return new Message("Say what?");
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
