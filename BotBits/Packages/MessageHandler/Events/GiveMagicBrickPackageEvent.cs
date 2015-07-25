using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("givemagicbrickpackage")]
    public sealed class GiveMagicBrickPackageEvent : ReceiveEvent<GiveMagicBrickPackageEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GiveMagicBrickPackageEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal GiveMagicBrickPackageEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.MagicPack = message.GetString(0);
        }

        public string MagicPack { get; set; }
    }
}