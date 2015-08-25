using System;
using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Raised when a received PlayerIOMessage could not be handled by BotBits.
    /// </summary>
    public sealed class UnknownMessageEvent : ReceiveEvent<UnknownMessageEvent>
    {
        public Exception Reason { get; private set; }

        internal UnknownMessageEvent(BotBitsClient client, Message message, Exception reason)
            : base(client, message)
        {
            this.Reason = reason;
        }
    }
}