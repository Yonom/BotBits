using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when world hidden in lobby setting is changed.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("hideLobby")]
    public sealed class HideLobbyEvent : ReceiveEvent<HideLobbyEvent>
    {
        internal HideLobbyEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            Hidden = message.GetBoolean(0);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether world is hidden.
        /// </summary>
        /// <value><c>true</c> if world is hidden; otherwise, <c>false</c>.</value>
        public bool Hidden { get; set; }
    }
}