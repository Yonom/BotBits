using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("givemagicsmiley")]
    public sealed class GiveMagicSmileyEvent : ReceiveEvent<GiveMagicSmileyEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GiveMagicSmileyEvent" /> class.
        /// </summary>
        /// <param name="client">The EE message.</param>
        /// <param name="message">The message.</param>
        internal GiveMagicSmileyEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.MagicSmiley = message.GetString(0);
        }

        public string MagicSmiley { get; set; }
    }
}