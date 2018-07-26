using ConsoleRPG.Game.Actions;
using System;
using System.Linq;
using Xunit;

namespace ConsoleRPGTests.Game.Actions
{
    public class ActionsTest
    {
        [Fact]
        public void LookActionReturnsCorrectDisplayText()
        {
            Assert.True(false);
        }

        [Fact]
        public void MessageActionReturnsCorrectDisplayText()
        {
            var text = "Hello World!";
            var action = new Message(text);
            Assert.Equal(text, action.Do().ToString());
        }

        [Fact]
        public void MoveActionReturnsCorrectDisplayText()
        {
            Assert.True(false);
        }

        [Fact]
        public void QuitActionReturnsCorrectDisplayText()
        {
            Assert.True(false);
        }

        [Fact]
        public void SayActionReturnsCorrectDisplayText()
        {
            Assert.True(false);
        }
    }
}
