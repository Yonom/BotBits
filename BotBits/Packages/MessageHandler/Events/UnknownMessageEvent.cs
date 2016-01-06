using System;
using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a received PlayerIOMessage could not be handled by BotBits.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    public sealed class UnknownMessageEvent : ReceiveEvent<UnknownMessageEvent>
    {
        internal UnknownMessageEvent(BotBitsClient client, Message message, Exception reason)
            : base(client, message)
        {
            Reason = reason;
        }

        /// <summary>
        ///     Gets the reason of the error.
        /// </summary>
        /// <value>The reason.</value>
        public Exception Reason { get; private set; }
    }
}