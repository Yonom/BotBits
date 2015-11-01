using PlayerIOClient;

namespace BotBits.Events
{
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

        public int Enabled { get; set; }

        public int SwitchId { get; set; }
    }
}