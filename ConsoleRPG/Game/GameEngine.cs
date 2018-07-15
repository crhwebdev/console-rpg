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



        public GameEngine()
        {
            _gameIsRunning = false;
            _console = new GameConsole();
            _commandInterpreter = new CommandInterpreter();
            _level = new Level();


        }

        public void Start()
        {
            _gameIsRunning = true;
            _console.SetDisplay(new DisplayTextLine("Game Engine starting....", ConsoleColor.Red));

            while (_gameIsRunning)
            {
                _console.Update();
                var input = _console.GetUserInput("What is your command?");

                if(input == "q")
                {
                    Stop();
                }
                
            }
        }

        private void Stop()
        {
            _gameIsRunning = false;
        }

        

        
    }
}
