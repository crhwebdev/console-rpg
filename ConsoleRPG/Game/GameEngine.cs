using ConsoleRPG.Game.Command;
using ConsoleRPG.System;
using ConsoleRPG.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game
{
    public class GameEngine
    {
        //This class does the following:
        // Instantiates all game components as private fields
        // Start method runs game loop
        // Stop method ends game loop and performs cleanup

       
        //Game Components
        private readonly GameConsole _console;
        private readonly CommandInterpreter _commandInterpreter;
        private Level _level;

        //Other Game Fields
        private bool _gameIsRunning = false;

        //Game Command List - add commads to this list to use in engine
        private List<ICommand> _commands = new List<ICommand>();

        public GameEngine(GameConsole console)
        {
            _console = console;
        }

        public GameEngine()
        {            
            _console = new GameConsole();
            //_commandInterpreter = new CommandInterpreter();
            //_level = new Level();

        }

        public void Start()
        {
            _gameIsRunning = true;            
            _console.Update(new DisplayTextLine("Game Engine starting....", ConsoleColor.Red));

            while (_gameIsRunning)
            {
                
                var input = _console.GetUserInput("What is your command, Master?");

                if(input == "quit")
                {
                    Stop();
                }
                
                _console.Update(new DisplayTextLine("Say what?"));                
                                
            }
        }

        private void Stop()
        {
            _gameIsRunning = false;
        }

        

        
    }
}
