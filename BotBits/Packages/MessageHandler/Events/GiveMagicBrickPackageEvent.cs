using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when you are given magic brick package.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
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

        /// <summary>
        ///     Gets or sets the magic pack identifier.
        /// </summary>
        /// <value>The magic pack.</value>
        public string MagicPack { get; set; }
    }
}