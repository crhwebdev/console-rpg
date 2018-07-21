using ConsoleRPG.Game;
using ConsoleRPG.Game.Actions;
using ConsoleRPG.Game.Actors;
using System;
using System.Linq;
using Xunit;

namespace ConsoleRPGTests.Game
{
    public class CommandInterpreterTest
    {
        //1. takes command text, parses it, and then outputs an action to be added to GameEngine's ActionQueue (or executed directly)

        // Should parse command string into appropriate action
        // should parse command string with target into action and target

        private Player _player;
        private CommandInterpreter _commandInterpreter;

        public CommandInterpreterTest()
        {
            var gameEngine = new GameEngine();
            _commandInterpreter = new CommandInterpreter(gameEngine);
            _player = new Player("Testy Tess");
            
        }

        [Fact]
        public void ParseCommandToAppropriateAction()
        {
            var returnAction = _commandInterpreter.Interpret("move", _player);
            Assert.IsType<Move>(returnAction);
        }
    }
}
