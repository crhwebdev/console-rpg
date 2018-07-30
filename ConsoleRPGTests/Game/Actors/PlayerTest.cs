using ConsoleRPG.Game;
using ConsoleRPG.Game.Actors;
using ConsoleRPG.Game.Locations;
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
        public void PlayerLookMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";
            var viewTargetDescription = "You see a test area.";
            var player = new Player(name);
            var viewTarget = new MockViewTarget();
            viewTarget.Description = viewTargetDescription;

            Assert.Equal(viewTargetDescription, player.Look(viewTarget).ToString());
        }

        [Fact]
        public void PlayerMoveMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";
            var viewTargetDescription = "You enter a test area.";
            var player = new Player(name);
            var viewTarget = new MockLocation("Test Area");
            viewTarget.Description = viewTargetDescription;

            Assert.Equal(viewTargetDescription, player.Move(viewTarget).ToString());
        }

        [Fact]
        public void PlayerSayMethodReturnsAppropriateText()
        {
            var name = "Testy Tess";
            var sayText = "Hello World!";
            var player = new Player(name);

            Assert.Equal("You say: '" + sayText + "'", player.Say(sayText).ToString());
        }
    }

    public class MockViewTarget : IViewable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DisplayText Viewed(Actor viewer)
        {
            return new DisplayText(Description);
        }
    }

    public class MockLocation : Location
    {
        
        public MockLocation(string name) : base(name)
        {
            
        }

        public override DisplayText Enter(Actor actor)
        {
            
            //get description of location and add to DisplayText to be returned
            var enterDisplayText = new DisplayText(Description);
            
            return enterDisplayText;
        }
    }
}
