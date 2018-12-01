using ConsoleRPG.Game.Interfaces;
using ConsoleRPG.Game.Locations;
using ConsoleRPG.Game.Props;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actors
{
    ////////////////////////////////////////////////////////////////////////////////////////
    //   CONSTRUCTOR
    //////////////////////////////////////////////////////////////////////////////////////// 

    public class NPC : Actor
    {
        public NPC(string name) : base(name)
        {            
            _actorAI = NPCCombatResolver.Instance(); //TODO: change this once an NPCAI class is created
        }

        public NPC(string name, ICombatResolver actorAI) : base(name)
        {
            _actorAI = actorAI;
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //   PUBLIC METHODS                          
        ////////////////////////////////////////////////////////////////////////////////////////        

        /// <summary>
        /// Handles Attack command for NPC
        /// </summary>
        /// <param name="commandClauseString"></param>
        /// <returns>DisplayText of results of attack</returns>
        public override DisplayText Attack(string commandClauseString)
        {
            return new DisplayText(Name + " attacks!");
        }

        public DisplayText Attacked(Actor attacker)
        {
            return new DisplayText("I was attacked");
        }
    }

  
}
