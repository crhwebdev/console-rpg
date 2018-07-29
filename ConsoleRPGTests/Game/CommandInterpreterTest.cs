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
        public void ParseCommandIntoActionAndTargetStringArray()
        {
            var commandString = "say at brown cow";
            var returnParsed = _commandInterpreter.ParseCommandString(commandString);
            Assert.Equal("say at", returnParsed[0]);
            Assert.Equal("brown cow", returnParsed[1]);

            commandString = "say brown cow";
            returnParsed = _commandInterpreter.ParseCommandString(commandString);
            Assert.Equal("say", returnParsed[0]);
            Assert.Equal("brown cow", returnParsed[1]);

            commandString = "say";
            returnParsed = _commandInterpreter.ParseCommandString(commandString);
            Assert.Equal("say", returnParsed[0]);
            Assert.Equal("", returnParsed[1]);


        }

        [Fact]
        public void ReturnNullWhenParseingEmptyString()
        {            
            var returnParsed = _commandInterpreter.ParseCommandString("");
            Assert.Null(returnParsed);                        
        }


        [Fact]
        public void ReturnsDropActionFromCommandList()
        {
            string[] commandList = { "drop", "thing" };
            var returnAction = _commandInterpreter.GetAction(commandList, _player);
            Assert.IsType<Drop>(returnAction);

        }

        [Fact]
        public void ReturnsGetActionFromCommandList()
        {
            string[] commandList = { "get", "thing" };
            var returnAction = _commandInterpreter.GetAction(commandList, _player);
            Assert.IsType<Get>(returnAction);

        }

        [Fact]
        public void ReturnsLookActionFromCommandList()
        {
            string[] commandList = { "look", "" };
            var returnAction = _commandInterpreter.GetAction(commandList, _player);
            Assert.IsType<Look>(returnAction);

        }

        
        [Fact]
        public void ReturnsMoveActionFromCommandList()
        {
            string[] commandList = { "move", "north" };
            var returnAction = _commandInterpreter.GetAction(commandList, _player);
            Assert.IsType<Move>(returnAction);

        }

        [Fact]
        public void ReturnsQuitActionFromCommandList()
        {
            string[] commandList = { "quit", "" };
            var returnAction = _commandInterpreter.GetAction(commandList, _player);
            Assert.IsType<Quit>(returnAction);

        }

        [Fact]
        public void ReturnsSayActionFromCommandList()
        {
            string[] commandList = {"say", "hello world"};
            var returnAction = _commandInterpreter.GetAction(commandList, _player);
            Assert.IsType<Say>(returnAction);
            
        }
    }
}
