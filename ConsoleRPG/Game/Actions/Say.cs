using ConsoleRPG.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    class Say
    {
        public string Display { get; set; }
        private Actor _actor;
        private string _text;

        public Say(Actor actor, string text)
        {
            _actor = actor;
            _text = text;
        }

        public void Do()
        {
            Display = _actor.Say(_text);
        }
    }
}
