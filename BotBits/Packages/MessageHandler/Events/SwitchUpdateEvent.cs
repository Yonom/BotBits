using BotBits.Models;
using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when someone touches purple switch.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("ps")]
    public sealed class SwitchUpdateEvent : PlayerEvent<SwitchUpdateEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SwitchUpdateEvent" /> class.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message">The EE message.</param>
        /// D
        internal SwitchUpdateEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.SwitchType = (SwitchType)message.GetInt(1);
            this.Id = message.GetInt(2);
            this.Enabled = message.GetBoolean(3);
        }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public SwitchType SwitchType { get; set; }

        /// <summary>
        ///     Gets or sets the value indicating whether the touched switch is activated.
        /// </summary>
        /// <value>The enabled.</value>
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the switch identifier.
        /// </summary>
        /// <value>The switch identifier.</value>
        public int Id { get; set; }
    }
}