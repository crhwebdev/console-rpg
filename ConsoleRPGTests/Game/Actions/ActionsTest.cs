using ConsoleRPG.Game;
using ConsoleRPG.Game.Actions;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
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
        private Item _testItem;
        

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

            _testItem = new Item("Key");
            _testArea.Items.Add(_testItem);
        }

        private void ResetPlayerLocation()
        {
            _testPlayer.Location = _testArea;
        }

        // TESTS

        // GET ACTION
        [Fact]
        public void GetActionCallsCorrectActorAction()
        {

            Assert.True(false);                                                
        }

        // DROP ACTION
        [Fact]
        public void DropActionCallsCorrectActorAction()
        {
            //returns error message for object not in player inventory

            //removes target object from player's inventory and adds it to their current location; displays appropriate text
            Assert.True(false);
        }


        //TODO Split test into 3 : looking at empty target, looing at inventory, and looking at object in location
        [Fact]
        public void LookActionCallsCorrectActorAction()
        {

            Assert.True(false);
        }

        
        [Fact]
        public void MoveActionCallsCorrectActorAction()
        {
            Assert.True(false);
        }

        //Skip testing Quit Action because it is a trivial implimentation and I don't want
        // to make private properties of GameEngine public just for testing

        [Fact]
        public void SayActionCallsCorrectActorAction()
        {
            Assert.True(false);
        }
    }

    class MockPlayer : Player
    {

        public MockPlayer(string name) : base(name)
        {

        }

        public override DisplayText Drop(Item droppedItem)
        {
            return new DisplayText("drop");
        }

        public override DisplayText Get(Item takenItem)
        {
            return new DisplayText("get");
        }

        public override DisplayText Look(IViewable viewedTarget)
        {
            return new DisplayText("look");
        }

        public override DisplayText Move(Location location)
        {
            return new DisplayText("move");
        }

        public override DisplayText Say(string text)
        {
            return new DisplayText("say");
        }
        
    }

    class MockArea : Location
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
