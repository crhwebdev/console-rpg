using ConsoleRPG.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.Game.Actions
{
    public class Message : IAction
    {
        private string _message;

        public Message(string message)
        {
            _message = message;
        }

        public DisplayText Do()
        {
            return new DisplayText(_message);
        }
    }
}
