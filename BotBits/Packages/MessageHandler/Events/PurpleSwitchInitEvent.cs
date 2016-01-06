using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs after join. Contains information about initial switch states.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("psi")]
    public sealed class PurpleSwitchInitEvent : PlayerEvent<PurpleSwitchInitEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PurpleSwitchInitEvent" /> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="message">The EE message.</param>
        internal PurpleSwitchInitEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            PurpleSwitches = MessageUtils.GetSwitches(message.GetByteArray(1));
        }

        /// <summary>
        ///     Gets or sets the purple switch states.
        /// </summary>
        /// <value>The purple switch states.</value>
        public int[] PurpleSwitches { get; set; }
    }
}