using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Actions;
using ConsoleRPG.System;
using ConsoleRPG.UI;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleRPG.Game.Locations;

namespace ConsoleRPG.Game
{
    public class GameEngine
    {
        //This class does the following:
        // Instantiates all game components as private fields
        // Start method runs game loop
        // Stop method ends game loop and performs cleanup

        public Actor Player { get; set; } = new Player("Carl The Destroyer");
        public Room Room { get; set; } = new Room("A dark dank chamber full of soft whisper voices...");

        //Game Components
        public TextConsole GameConsole { get; set;}
        //private readonly CommandInterpreter _commandInterpreter;
        //private Level _level;

        //Other Game Fields
        private bool _gameIsRunning = false;

        //Game Command List - add commads to this list to use in engine
        private List<IAction> _commands = new List<IAction>();    
        

        public GameEngine()
        {            
            GameConsole = new GameConsole();
            
        }
        
        public void Start()
        {
            _gameIsRunning = true;            
            

            while (_gameIsRunning)
            {
                
                var input = GameConsole.GetUserInput();

                if(input == "quit")
                {
                    GameConsole.WriteDisplayTextLine(new DisplayTextLine("Stopping..."));
                    Stop();
                }
                else if(input == "look")
                {
                    var look = new Look(Player);
                    
                    GameConsole.WriteDisplayText(look.Do());
                }
                else if(input == "move")
                {
                    var move = new Move(Player, Room);                    
                    GameConsole.WriteDisplayText(move.Do());
                }
                else if(input == "say hello")
                {
                    var say = new Say(Player, "hello");
                    
                    GameConsole.WriteDisplayText(say.Do());
                }
                else
                {
                    GameConsole.WriteDisplayTextLine(new DisplayTextLine("Say what?"));
                }
                                                                
            }
        }

        private void Stop()
        {
            _gameIsRunning = false;
        }

        private void Update()
        {
            GameConsole.WriteDisplayTextLine(new DisplayTextLine("Game Engine starting...."));
        }
                                
    }
}
