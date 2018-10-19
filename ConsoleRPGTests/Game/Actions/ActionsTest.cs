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
        

        public ActionsTest()
        {
            _testPlayer = new MockPlayer("Test Dude");                        
        }

        // TESTS
        // ATTACK ACTION
        [Fact]
        public void AttackActionCallsCorrectActorAction()
        {
            var action = new Attack(_testPlayer, "");
            Assert.Equal("attack", action.Do().ToString());
        }

        // TESTS
        // DROP ACTION
        [Fact]
        public void DropActionCallsCorrectActorAction()
        {
            var action = new Drop(_testPlayer, "");
            Assert.Equal("drop", action.Do().ToString());
        }

        // TESTS
        // EQUIP ACTION
        [Fact]
        public void EquipActionCallsCorrectActorAction()
        {
            var action = new Equip(_testPlayer, "");            
            Assert.Equal("equip", action.Do().ToString());
        }

        // GET ACTION
        [Fact]
        public void GetActionCallsCorrectActorAction()
        {
            var action = new Get(_testPlayer, "");
            Assert.Equal("get", action.Do().ToString());                                      
        }


        // INVENTORY ACTION
        [Fact]
        public void InventoryActionCallsCorrectActorAction()
        {
            var action = new Inventory(_testPlayer);
            Assert.Equal("showinventory", action.Do().ToString());
        }

        // LOOK ACTION
        [Fact]
        public void LookActionCallsCorrectActorAction()
        {
            var action = new Look(_testPlayer, "");
            Assert.Equal("look", action.Do().ToString());
        }

        // MOVE ACTION
        [Fact]
        public void MoveActionCallsCorrectActorAction()
        {
            var action = new Move(_testPlayer, "");
            Assert.Equal("move", action.Do().ToString());
        }

        //Skip testing Quit Action because it is a trivial implimentation and I don't want
        // to make private properties of GameEngine public just for testing

        // SAY ACTION
        [Fact]
        public void SayActionCallsCorrectActorAction()
        {
            var action = new Say(_testPlayer, "");
            Assert.Equal("say", action.Do().ToString());
        }

        // TESTS
        // UNEQUIP ACTION
        [Fact]
        public void UnequipActionCallsCorrectActorAction()
        {
            var action = new Unequip(_testPlayer, "");
            Assert.Equal("unequip", action.Do().ToString());
        }
    }

    class MockPlayer : Player
    {
        public MockPlayer(string name) : base(name) {}

        public override DisplayText Attack(string commandClauseString)
        {
            return new DisplayText("attack");
        }

        public override DisplayText Drop(string commandClauseString)
        {
            return new DisplayText("drop");
        }

        public override DisplayText Equip(string commandClauseString)
        {
            return new DisplayText("equip");
        }

        public override DisplayText Get(string commandClauseString)
        {
            return new DisplayText("get");
        }

        public override DisplayText Look(string commandClauseString)
        {
            return new DisplayText("look");
        }

        public override DisplayText Move(string commandClauseString)
        {
            return new DisplayText("move");
        }

        public override DisplayText Say(string commandClauseString)
        {
            return new DisplayText("say");
        }

        public override DisplayText ShowInventory()
        {
            return new DisplayText("showinventory");
        }

        public override DisplayText Unequip(string commandClauseString)
        {
            return new DisplayText("unequip");
        }
    }    
}
