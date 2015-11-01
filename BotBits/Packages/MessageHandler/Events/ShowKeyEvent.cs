using System;
using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("show")]
    public sealed class ShowKeyEvent : ReceiveEvent<ShowKeyEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ShowKeyEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal ShowKeyEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Key = (Key) Enum.Parse(typeof (Key), message.GetString(0), true);
        }

        /// <summary>
        ///     Gets or sets the keys.
        /// </summary>
        /// <value>The keys.</value>
        public Key Key { get; set; }
    }
}