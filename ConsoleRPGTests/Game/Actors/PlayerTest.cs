using ConsoleRPG.Game;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
using ConsoleRPG.System;
using System;
using System.Linq;
using Xunit;

namespace ConsoleRPGTests.Game.Actors
{
    public class PlayerTest
    {
        [Fact]
        public void CanInstantiateAPlayerWithAName()
        {
            var name = "Testy Tess";
            var player = new Player(name);

            Assert.Equal(name, player.Name);
        }


        // DROP METHOD
        [Fact]
        public void PlayerDropMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";            
            var player = new Player(name);
            var playerLocation = new MockLocation("Test Area");
            var itemTargetName = "Thing";
            var itemTarget = new MockItemTarget(itemTargetName);

            player.Location = playerLocation;
            player.Inventory.Add(itemTarget);

            // player displays correct error message when passing empty target string
            var playerDropText = player.Get("").ToString();
            Assert.Equal("There is nothing to drop!", playerDropText);

            //player displays correct error message when getting an item that doesn't exist
            playerDropText = player.Get("wtf").ToString();
            Assert.Equal("You don't have that item!", playerDropText);

            // player displays correct text when dropping item
            playerDropText = player.Drop(itemTargetName).ToString();
            Assert.Equal(player.Name + " drops the " + itemTarget.Name, playerDropText);

            // player successfully removes item from inventory
            Assert.Empty(player.Inventory);

            // player succesfully adds item to Location.Items list
            Assert.Single(playerLocation.Items, itemTarget);

        }

        //GET METHOD
        [Fact]
        public void PlayerGetMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";            
            var player = new Player(name);
            var playerLocation = new MockLocation("Test Area");
            var itemTargetName = "Thing";
            var itemTarget = new MockItemTarget(itemTargetName);

            player.Location = playerLocation;
            playerLocation.Items.Add(itemTarget);

            // player displays correct error message when passing empty target string
            var playerGetText = player.Get("").ToString();
            Assert.Equal("There is nothing to get!", playerGetText);

            //player displays correct error message when getting an item that doesn't exist
            playerGetText = player.Get("wtf").ToString();
            Assert.Equal("You cannot get that!", playerGetText);

            // player displays correct text when getting item 
            playerGetText = player.Get(itemTargetName).ToString();
            Assert.Equal(player.Name + " gets the " + itemTarget.Name, playerGetText);

            // player successfully removed item from location
            Assert.Empty(playerLocation.Items);
            // player succesfully added item to inventory
            Assert.Single(player.Inventory, itemTarget);
        }

        // LOOK METHOD
        [Fact]
        public void PlayerLookMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";            
            var player = new Player(name);
            var viewedLocation = new MockLocation("Test Area");
            player.Location = viewedLocation;
            
            //player displays correct text for location as view target
            Assert.Equal(player.Name + " looks around...", player.Look("").ToString());

            //player displays correct text when looking at an Actor as view target            
            var viewedActorTargetName = "View Target";
            var viewedActorTarget = new MockActorTarget(viewedActorTargetName);

            player.Location.Actors.Add(viewedActorTarget);

            Assert.Equal(player.Name + " looks at " + viewedActorTarget.Name, player.Look(viewedActorTargetName).ToString());
        }

        
        // MOVE METHOD
        [Fact]
        public void PlayerMoveMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";          
            var player = new Player(name);
            var startLocation = new MockLocation("Start Area");
            var destinationLocation = new MockLocation("Destination Area");            
            player.Location = startLocation;
            startLocation.ExitNorth = destinationLocation;

            //move to exit without link to new location
            Assert.Equal(player.Name + " cannot move there!", player.Move("south").ToString());
            player.Location = startLocation;

            //no target given
            Assert.Equal(player.Name + " cannot move there!", player.Move("").ToString());
            player.Location = startLocation;

            //move to exit with link to new location
            Assert.Equal(player.Name + " moves...", player.Move("north").ToString());                        
        }


        // SAY METHOD
        [Fact]
        public void PlayerSayMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";
            var sayText = "Hello World!";
            var player = new Player(name);

            Assert.Equal(player.Name + " says: '" + sayText + "'", player.Say(sayText).ToString());
        }
    }

    public class MockActorTarget : Actor
    {
        
        public MockActorTarget(string name) : base(name) {}

        public override DisplayText Viewed(Actor viewer)
        {
            return new DisplayText();
        }
    }

    public class MockItemTarget : Item
    {
        public MockItemTarget(string name) : base(name) {}

        public override DisplayText Taken()
        {
            return new DisplayText();
        }

        public override DisplayText Dropped()
        {
            return new DisplayText();
        }
    }

    public class MockLocation : Location
    {        
        public MockLocation(string name) : base(name) {}

        public override DisplayText Viewed(Actor viewer)
        {
            return new DisplayText();
        }

        public override DisplayText Enter(Actor actor)
        {            
            //get description of location and add to DisplayText to be returned
            var enterDisplayText = new DisplayText();
            
            return enterDisplayText;
        }
    }
}
