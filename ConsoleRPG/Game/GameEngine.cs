using ConsoleRPG.System;
using ConsoleRPG.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game
{
    public static class GameEngine
    {
        //This class does the following:
        //1. Contains an instance of the GameConsole to which it outputs text and from which it recieves commands
        //2. Contains an instance of a Level with which it interacts
        //3. Starts up and loads level data, intializes values, and the main game loop
        //4. Main game loop updates the GameConsole, updates the game, and then gets user input from the GameConsole and sends it to the CommandInterpreter
        //5. The CommandInterpreter parses input and dispatches commands
        //6. ScreenManager sets which mode the game is opperating (menu, dialogue, explorable)
        private static GameConsole _console = new GameConsole();
        
        public static void Start()
        {
            _console.SetDisplay(new DisplayTextLine("Game Engine starting....", ConsoleColor.Red));

            while (true)
            {
                _console.Update();
                var input = _console.GetUserInput("What is your command?");

                if(input == "q")
                {
                    break;
                }
                
            }
        }

        
    }
}
