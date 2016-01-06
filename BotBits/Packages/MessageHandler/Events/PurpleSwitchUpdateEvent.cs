using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when someone touches purple switch.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("ps")]
    public sealed class PurpleSwitchUpdateEvent : PlayerEvent<PurpleSwitchUpdateEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PurpleSwitchUpdateEvent" /> class.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message">The EE message.</param>
        /// D
        internal PurpleSwitchUpdateEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.SwitchId = message.GetInt(1);
            this.Enabled = message.GetInt(2);
        }

        /// <summary>
        ///     Gets or sets the value indicating whether the touched switch is activated.
        /// </summary>
        /// <value>The enabled.</value>
        public int Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the switch identifier.
        /// </summary>
        /// <value>The switch identifier.</value>
        public int SwitchId { get; set; }
    }
}