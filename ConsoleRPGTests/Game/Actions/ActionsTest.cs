using ConsoleRPG.Game;
using ConsoleRPG.Game.Actions;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
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

            //var target = "";
            //var action = new Look(new MockPlayer("The Test Dude"), target);
            //Look with empty target - should return location description
            Assert.True(false);
            //Look with actor target - should return actor description
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
            //Move with wrong direction
            Assert.True(false);
            //Move with correct direction
        }

        [Fact]
        public void QuitActionReturnsCorrectDisplayText()
        {
            //not sure how to test?  Would need access to IsRunning property of GameEngine
            Assert.True(false);
        }

        [Fact]
        public void SayActionReturnsCorrectDisplayText()
        {
            var text = "Hello World!";
            var mockPlayer = new MockPlayer("The Test Dude");
            var action = new Say(mockPlayer, text);
            Assert.Equal("You say: " + text, action.Do().ToString());
        }
    }

    class MockPlayer : Player
    {

        public MockPlayer(string name) : base(name)
        {

        }

        public override DisplayText Look(IViewable viewedTarget)
        {
            return new DisplayText("You see stuff.");
        }
        public override DisplayText Say(string text)
        {
            return new DisplayText("You say: " + text);
        }
        public override DisplayText Move(Location location)
        {
            return new DisplayText("You move!");
        }
    }

    class MockLocation : Location
    {
        public MockLocation(string name) : base(name)
        {

        }
    }

    class MockViewedTarget : IViewable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DisplayText Viewed(Actor viewer)
        {
            return new DisplayText();
        }
    }
}
