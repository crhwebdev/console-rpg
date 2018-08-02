﻿using ConsoleRPG.Game;
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

            Assert.True(false);
        }

        //GET METHOD
        [Fact]
        public void PlayerGetMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";            
            var player = new Player(name);

            Assert.True(false);
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
