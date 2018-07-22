using ConsoleRPG.Game.Actors;
using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Say : Action
    {
        public string Display { get; set; }
        private Actor _actor;
        private string _text;

        public Say(Actor actor, string text)
        {
            _actor = actor;
            _text = text;
        }

        public override DisplayText Do()
        {
            var displayText = _actor.Say(_text);
            return displayText;
        }
    }
}
