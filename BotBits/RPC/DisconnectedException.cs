using System;

namespace BotBits
{
    public class DisconnectedException : Exception
    {
        public DisconnectedException(string message)
            : base(message)
        {
        }
    }
}
