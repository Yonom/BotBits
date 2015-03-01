using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("c")]
    public sealed class CoinEvent : PlayerEvent<CoinEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CoinEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal CoinEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.GoldCoins = message.GetInteger(1);
            this.BlueCoins = message.GetInteger(2);
        }

        /// <summary>
        ///     Gets or sets the coins of the player.
        /// </summary>
        /// <value>The coins.</value>
        public int GoldCoins { get; set; }

        /// <summary>
        ///     Gets or sets the blue coins of the player.
        /// </summary>
        /// <value>The blue coins.</value>
        public int BlueCoins { get; set; }
    }
}