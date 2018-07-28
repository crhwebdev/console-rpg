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

        private void ResetPlayerLocation()
        {
            _testPlayer.Location = _testArea;
        }

        // TESTS

        // GET ACTION
        [Fact]
        public void GetActionReturnsCorrectDisplayTextAndRemovesItemFromRoom()
        {
            Assert.True(false);
        }

        // DROP ACTION
        [Fact]
        public void DropActionReturnsCorrectDisplayTextAndAddsItemToRoomAndRemovesFromPlayerInventory()
        {
            Assert.True(false);
        }


        //TODO Split test into 3 : looking at empty target, looing at inventory, and looking at object in location
        [Fact]
        public void LookActionReturnsCorrectDisplayText()
        {

            var target = "";
            var action = new Look(_testPlayer, target);
            //Look with empty target - should return location description
            Assert.Equal("a very testing area indeed.", action.Do().ToString());
            //Look with actor target - should return actor description
            target = "Other Test Dude";
            action = new Look(_testPlayer, target);
            Assert.Equal("a very testy dude.", action.Do().ToString());
            //Look with actor target and different case - should return actor description
            target = "other test dude";
            action = new Look(_testPlayer, target);
            Assert.Equal("a very testy dude.", action.Do().ToString());
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
            var moveRightDirection = new Move(_testPlayer, "North");
            Assert.Equal("You move!", moveRightDirection.Do().ToString());
            //Move with direction using different case
            moveRightDirection = new Move(_testPlayer, "north");
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
            return viewedTarget.Viewed(this);
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

        public override DisplayText Viewed(Actor viewer)
        {
            var viewedDisplayText = new DisplayText(Description);
            
            return viewedDisplayText;
        }
    }

    class MockNPC : NPC
    {
        public MockNPC(string name) : base(name){ }

        public override DisplayText Viewed(Actor viewer)
        {
            return new DisplayText(Description);
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
