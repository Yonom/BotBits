using System;
using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("hide")]
    public sealed class HideKeyEvent : ReceiveEvent<HideKeyEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HideKeyEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal HideKeyEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Keys = new Key[message.Count];
            for (uint i = 0; i <= message.Count - 1u; i++)
            {
                this.Keys[(int)i] = (Key)Enum.Parse(typeof(Key), message.GetString(i), true);
            }
        }

        /// <summary>
        ///     Gets or sets the keys.
        /// </summary>
        /// <value>The keys.</value>
        public Key[] Keys { get; set; }
    }
}