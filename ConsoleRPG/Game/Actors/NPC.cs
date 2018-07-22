using ConsoleRPG.Game.Locations;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actors
{
    class NPC : Actor
    {
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
}
