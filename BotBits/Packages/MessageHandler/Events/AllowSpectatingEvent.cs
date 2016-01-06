using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when spectating in the world setting is changed.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("allowSpectating")]
    public sealed class AllowSpectatingEvent : ReceiveEvent<AllowSpectatingEvent>
    {
        internal AllowSpectatingEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            Allow = message.GetBoolean(0);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether spectating is allowed.
        /// </summary>
        /// <value><c>true</c> if spectating is allowed; otherwise, <c>false</c>.</value>
        public bool Allow { get; set; }
    }
}