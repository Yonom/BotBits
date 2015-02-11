using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("givemagicsmiley")]
    public sealed class GiveMagicSmiley : ReceiveEvent<GiveMagicSmiley>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GiveMagicSmiley" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal GiveMagicSmiley(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.MagicSmiley = message.GetString(0);
        }

        public string MagicSmiley { get; set; }
    }
}