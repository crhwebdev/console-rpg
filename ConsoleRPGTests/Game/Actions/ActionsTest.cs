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
        private MockPlayer _testPlayer;
        private MockArea   _testArea;
        private MockArea _testArea2;
        private MockNPC _testNPC;
        

        public ActionsTest()
        {
            _testPlayer = new MockPlayer("The Test Dude");
            

            _testArea = new MockArea("Testing Grounds")
            {
                Description = "a very testing area indeed."                
            };

            _testArea2 = new MockArea("Another Testing Grounds")
            {
                Description = "another very testing area indeed."
            };

            _testArea.ExitNorth = _testArea2;            
            _testArea2.ExitSouth = _testArea;
            _testPlayer.Location = _testArea;


            _testNPC = new MockNPC("Other Test Dude")
            {
                Description = "a very testy dude."
            };

            _testArea.Actors.Add(_testNPC);
        }

        public void ResetPlayerLocation()
        {
            _testPlayer.Location = _testArea;
        }

        [Fact]
        public void LookActionReturnsCorrectDisplayText()
        {

            //var target = "";
            //var action = new Look(_testPlayer, target);
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
            var moveWrongDirection = new Move(_testPlayer, "west");
            Assert.Equal("You cannot move there!", moveWrongDirection.Do().ToString());
            ResetPlayerLocation();
            //Move with correct direction
            var moveRightDirection = new Move(_testPlayer, "north");
            Assert.Equal("You move!", moveRightDirection.Do().ToString());

            ResetPlayerLocation();
        }

        //Skip testing Quit Action because it is a trivial implimentation and I don't want
        // to make private properties of GameEngine public just for testing

        [Fact]
        public void SayActionReturnsCorrectDisplayText()
        {
            var text = "Hello World!";            
            var action = new Say(_testPlayer, text);
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

    class MockArea : Area
    {
        public MockArea(string name) : base(name)
        {

        }
    }

    class MockNPC : NPC
    {
        public MockNPC(string name) : base(name){ }

        public override DisplayText Viewed(Actor viewer)
        {
            return new DisplayText("You see " + Name);
        }
    
        //Has various methods that correspond to actions that can be executed with him as the reciever
        public override DisplayText Look(IViewable viewedTarget)
        {
            throw new NotImplementedException();
        }

        public override DisplayText Say(string text)
        {
            throw new NotImplementedException();
        }
        public override DisplayText Move(Location location)
        {
            throw new NotImplementedException();
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
