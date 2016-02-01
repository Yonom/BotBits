using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when minimap is enabled or disabled.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("minimapEnabled")]
    public sealed class MinimapEnabledEvent : ReceiveEvent<MinimapEnabledEvent>
    {
        internal MinimapEnabledEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Enabled = message.GetBoolean(0);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether minimap is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled { get; set; }
    }
}