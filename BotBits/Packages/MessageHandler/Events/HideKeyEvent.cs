using System;
using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player touches a key or timed doors change their state.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("hide")]
    public sealed class HideKeyEvent : PlayerEvent<HideKeyEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HideKeyEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal HideKeyEvent(BotBitsClient client, Message message)
            : base(client, message, 1)
        {
            this.Key = (Key)Enum.Parse(typeof(Key), message.GetString(0), true);
        }

        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public Key Key { get; set; }
    }
}