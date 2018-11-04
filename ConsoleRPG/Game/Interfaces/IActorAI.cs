using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Interfaces
{
    public interface IActorAI
    {
        DisplayText DetermineCombatRound(Actor host, Actor target);
        
    }
}
