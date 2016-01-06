using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when you successfully muted or un-umted someone.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("muted")]
    public sealed class MutedEvent : PlayerEvent<MutedEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MutedEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal MutedEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            Muted = message.GetBoolean(1);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether player is muted.
        /// </summary>
        /// <value><c>true</c> if muted; otherwise, <c>false</c>.</value>
        public bool Muted { get; set; }
    }
}