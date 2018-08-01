using ConsoleRPG.Game;
using ConsoleRPGTests.Mocks;
using System;
using System.Linq;
using Xunit;

namespace ConsoleRPGTests.Game
{
    public class GameEngineTest
    {
        private GameEngine _game;

        public GameEngineTest()
        {
            _game = GameEngine.Instance();
            _game.GameConsole = new MockGameConsole();
        }

        //Game engine outputs text to console when started
        [Fact]
        public void Game()
        {
            
            Assert.True(false);
        }

        [Fact]
        public void GameEngineStartRunsGame()
        {
            Assert.True(false);
        }
    }
}
