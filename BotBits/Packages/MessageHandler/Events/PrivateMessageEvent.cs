using System;
using System.Diagnostics;
using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a private message from player is received.
    /// </summary>
    [ReceiveEvent("pm")]
    public sealed class PrivateMessageEvent : PlayerEvent<PrivateMessageEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PrivateMessageEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal PrivateMessageEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Message = message.GetString(1);
            this.Incoming = message.GetBoolean(2);
        }

        /// <summary>
        ///     Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; private set; }

        /// <summary>
        ///     Gets the value that indicates if message is incoming or outgoing.
        /// </summary>
        /// <value><c>true</c> if incoming; <c>false</c> if outgoing.</value>
        public bool Incoming { get; private set; }
    }
}