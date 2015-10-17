using PlayerIOClient;

namespace BotBits.Events
{
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
            this.PurpleSwitches = MessageUtils.GetSwitches(message.GetByteArray(1));
        }

        public int[] PurpleSwitches { get; set; }
    }
}