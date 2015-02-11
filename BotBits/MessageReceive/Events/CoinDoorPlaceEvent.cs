using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("bc")]
    public sealed class CoinDoorPlaceEvent : PlayerEvent<CoinDoorPlaceEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CoinDoorPlaceEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal CoinDoorPlaceEvent(BotBitsClient client, Message message)
            : base(client, message, 4)
        {
            this.X = message.GetInteger(0);
            this.Y = message.GetInteger(1);
            this.Id = message.GetInteger(2);
            this.CoinsToOpen = message.GetUInt(3);
        }

        /// <summary>
        ///     Gets or sets the amount of coins that is needed to open the coin door.
        /// </summary>
        /// <value>The coins to open.</value>
        public uint CoinsToOpen { get; set; }

        /// <summary>
        ///     Gets or sets the block id.
        /// </summary>
        /// <value>
        ///     The block id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the position x of the player.
        /// </summary>
        /// <value>The position x.</value>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the position y of the player.
        /// </summary>
        /// <value>The position y.</value>
        public int Y { get; set; }
    }
}