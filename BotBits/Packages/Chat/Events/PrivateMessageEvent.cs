using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotBits.Events
{
    public sealed class PrivateMessageEvent : Event<PrivateMessageEvent>
    {
        public string Username { get; private set; }
        public string Message { get; private set; }

        internal PrivateMessageEvent(string username, string message)
        {
            this.Username = username;
            this.Message = message;
        }
    }
}
