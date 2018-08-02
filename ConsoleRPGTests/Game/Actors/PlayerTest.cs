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

        [Fact]
        public void PlayerDropMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";            
            var player = new Player(name);

            Assert.True(false);
        }

        [Fact]
        public void PlayerGetMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";            
            var player = new Player(name);

            Assert.True(false);
        }

        [Fact]
        public void PlayerLookMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";            
            var player = new Player(name);
            var viewedLocation = new MockLocation("Test Area");
            player.Location = viewedLocation;

            //player displays correct text for location as view target
            Assert.Equal(player.Name + " looks around...", player.Look(viewedLocation).ToString());

            //player displays correct text when looking at a specific target
            var viewedTarget = new MockViewTarget();
            Assert.Equal(player.Name + " looks at " + viewedTarget.Name, player.Look(viewedTarget).ToString());
        }

        

        [Fact]
        public void PlayerMoveMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";          
            var player = new Player(name);
            var viewTarget = new MockLocation("Test Area");            

            Assert.Equal(player.Name + " moves...", player.Move(viewTarget).ToString());
        }

        [Fact]
        public void PlayerSayMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";
            var sayText = "Hello World!";
            var player = new Player(name);

            Assert.Equal(player.Name + " says: '" + sayText + "'", player.Say(sayText).ToString());
        }
    }

    public class MockViewTarget : IViewable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DisplayText Viewed(Actor viewer)
        {
            return new DisplayText();
        }
    }

    public class MockItemTarget : Item
    {
        MockItemTarget(string name) : base(name)
        {

        }

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
        
        public MockLocation(string name) : base(name)
        {
            
        }

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
