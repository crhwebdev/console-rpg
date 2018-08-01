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


        public Actor Player { get; set; }        

        //Game Components
        public TextConsole GameConsole { get; set;}
        public CommandInterpreter CommandInterpreter { get; set; }
        public Level CurrentAdventure;


        //Other Game Fields
        private static GameEngine _gameEngine = null;
        private bool _gameIsRunning = false;

        //Game Command List - add commads to this list to use in engine
        private List<Actions.Action> _commands = new List<Actions.Action>();    
        

        protected GameEngine()
        {            
            GameConsole = new GameConsole();
            CommandInterpreter = new CommandInterpreter(this);            
        }

        public static GameEngine Instance()
        {
            if(_gameEngine == null)
            {
                _gameEngine = new GameEngine();
            }

            return _gameEngine;
        }
        
        public void Start()
        {
            _gameIsRunning = true;
            CurrentAdventure = new TestDungeon();
            Player = new Player("Carl The Destroyer");
            Player.Location = CurrentAdventure.StartingLocation;

            GameConsole.WriteDisplayText(CurrentAdventure.StartingLocation.Viewed(Player));
            
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
