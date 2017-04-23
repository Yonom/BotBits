using System;

namespace BotBits
{
    public class MailDeliveryException : Exception
    {
        public MailDeliveryException(string message)
            : base(message)
        {
        }
    }
}