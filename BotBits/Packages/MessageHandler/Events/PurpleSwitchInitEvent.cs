using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("psi")]
    public sealed class PurpleSwitchInitEvent : PlayerEvent<PurpleSwitchInitEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PurpleSwitchInitEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="message">The message.</param>
        internal PurpleSwitchInitEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.PurpleSwitches = message.GetByteArray(1);
        }

        public byte[] PurpleSwitches { get; set; }
    }
}