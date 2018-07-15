using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG.System
{
    public class Message
    {        
        public List<string> Content { get; private set; }
                    
        public Message()
        {
            Content = new List<string>();
        }

        public Message(string message)
        {
            Content = new List<string> { message };
        }

        public Message(List<string> messages)
        {
            Content = messages;
        }


    }
}
