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

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PROTECTED CONSTRUCTOR - SINGLETON CLASS                         
        ////////////////////////////////////////////////////////////////////////////////////////

        protected GameEngine()
        {
            GameConsole = new GameConsole();
            CommandInterpreter = CommandInterpreter.Instance(this);
            _gameIsRunning = false;
            ActionQueue = new Queue<Actions.Action>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC PROPS                          
        ////////////////////////////////////////////////////////////////////////////////////////

        public Actor Player { get; set; }        
        public TextConsole GameConsole { get; set;}
        public CommandInterpreter CommandInterpreter { get; set; }
        public Level CurrentAdventure { get; set; }
        public Queue<Actions.Action> ActionQueue { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PRIVATE FIELDS                          
        ////////////////////////////////////////////////////////////////////////////////////////

        private static GameEngine _instance = null;
        private bool _gameIsRunning;



        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        ////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Get an instance of the GameEngine if it already exists
        /// or create a new one if it dosen't
        /// </summary>
        /// <returns>Instance of GameEngine</returns>
        public static GameEngine Instance()
        {
            if(_instance == null)
            {
                _instance = new GameEngine();
            }

            return _instance;
        }
        
        /// <summary>
        /// Start GameEngine and run game loop
        /// </summary>
        public void Start()
        {
            _gameIsRunning = true;
            CurrentAdventure = new TestDungeon();
            Player = new Player("Carl The Destroyer");
            Player.Sex = Sexes.Male;
            Player.Location = CurrentAdventure.StartingLocation;

            GameConsole.WriteDisplayText(CurrentAdventure.StartingLocation.Viewed(Player));
            
            while (_gameIsRunning)
            {                
                var input = GameConsole.GetUserInput();
                var action = CommandInterpreter.GetAction(CommandInterpreter.ParseCommandString(input), Player);
                ActionQueue.Enqueue(action);
                Update();                
            }
        }

        /// <summary>
        /// Stop GameEngine
        /// </summary>
        public void Stop()
        {
            _gameIsRunning = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PRIVATE METHODS                          
        ////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Update method that runs actions in ActionQueue and updates display
        /// </summary>
        private void Update()
        {

            while (ActionQueue.Count > 0)
            {
                var currentAction = ActionQueue.Dequeue();
                GameConsole.WriteDisplayText(currentAction.Do());
            }           
                                                   
        }                                
    }
}
