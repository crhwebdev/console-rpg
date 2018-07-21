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

        //Game Components
        public TextConsole GameConsole { get; set;}
        public CommandInterpreter CommandInterpreter { get; set; }
        //private Level _level;

        //Other Game Fields
        private bool _gameIsRunning = false;

        //Game Command List - add commads to this list to use in engine
        private List<IAction> _commands = new List<IAction>();    
        

        public GameEngine()
        {            
            GameConsole = new GameConsole();
            CommandInterpreter = new CommandInterpreter(this);            
        }
        
        public void Start()
        {
            _gameIsRunning = true;            
            

            while (_gameIsRunning)
            {                
                var input = GameConsole.GetUserInput();
                var action = CommandInterpreter.GetAction(CommandInterpreter.ParseCommandString(input), Player);
                GameConsole.WriteDisplayText(action.Do());
            }
        }

        public void Stop()
        {
            _gameIsRunning = false;
        }

        private void Update()
        {
            GameConsole.WriteDisplayTextLine(new DisplayTextLine("Game Engine starting...."));
        }
                                
    }
}
