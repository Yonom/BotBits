using System;
using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Coin Send Event
    /// </summary>
    public sealed class CoinSendMessage : SendMessage<CoinSendMessage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoinSendMessage"/> class.
        /// </summary>
        /// <param name="coins">The gold coins count.</param>
        /// <param name="blueCoins">The blue coins count.</param>
        /// <param name="coinX">The coin x-coordinate.</param>
        /// <param name="coinY">The coin y-coordinate.</param>
        public CoinSendMessage(int coins, int blueCoins, uint coinX, uint coinY)
        {
            this.Coins = coins;
            this.BlueCoins = blueCoins;
            this.CoinX = coinX;
            this.CoinY = coinY;
        }

        /// <summary>
        ///     Gets or sets the coin x-coordinate.
        /// </summary>
        /// <value>
        ///     The coin x-coordinate.
        /// </value>
        public uint CoinX { get; set; }

        /// <summary>
        ///     Gets or sets the coin y-coordinate.
        /// </summary>
        /// <value>
        ///     The coin y-coordinate.
        /// </value>
        public uint CoinY { get; set; }

        /// <summary>
        ///     Gets or sets the number of yellow coins the player has.
        /// </summary>
        /// <value>
        ///     The number of yellow coins the player has.
        /// </value>
        public int Coins { get; set; }

        /// <summary>
        ///     Gets or sets the number of blue coins the player has.
        /// </summary>
        /// <value>
        ///     The number of blue coins the player has.
        /// </value>
        public int BlueCoins { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("c", this.Coins, this.BlueCoins, this.CoinX, this.CoinY);
        }
    }
}