using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when moderator toggles moderator mode.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("mod")]
    public sealed class ModModeEvent : PlayerEvent<ModModeEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ModModeEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal ModModeEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.ModMode = message.GetBoolean(1);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether moderator is in moderator mode.
        /// </summary>
        /// <value><c>true</c> if mod; otherwise, <c>false</c>.</value>
        public bool ModMode { get; set; }
    }
}
