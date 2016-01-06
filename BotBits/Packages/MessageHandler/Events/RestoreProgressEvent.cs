using System.Linq;
using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when your campaign progress is restored.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("restoreProgress")]
    public sealed class RestoreProgressEvent : PlayerEvent<RestoreProgressEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RestoreProgressEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal RestoreProgressEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.X = message.GetDouble(1);
            this.Y = message.GetDouble(2);
            this.GoldCoins = message.GetInteger(3);
            this.BlueCoins = message.GetInteger(4);
            var goldCoinPosXs = message.GetByteArray(5);
            var goldCoinPosYs = message.GetByteArray(6);
            this.GoldCoinPoints = WorldUtils.GetPos(goldCoinPosXs, goldCoinPosYs).ToArray();
            var blueCoinPosXs = message.GetByteArray(7);
            var blueCoinPosYs = message.GetByteArray(8);
            this.BlueCoinPoints = WorldUtils.GetPos(blueCoinPosXs, blueCoinPosYs).ToArray();
            this.Deaths = message.GetInteger(9);
            this.CheckpointX = message.GetInteger(10);
            this.CheckpointY = message.GetInteger(11);
            this.PurpleSwitches = MessageUtils.GetSwitches(message.GetByteArray(12));
            this.SpeedX = message.GetDouble(13);
            this.SpeedX = message.GetDouble(14);
        }

        /// <summary>
        ///     Gets or sets the blue coin positions.
        /// </summary>
        /// <value>The blue coin positions.</value>
        public Point[] BlueCoinPoints { get; set; }

        /// <summary>
        ///     Gets or sets the gold coin positions.
        /// </summary>
        /// <value>The gold coin positions.</value>
        public Point[] GoldCoinPoints { get; set; }

        /// <summary>
        ///     Gets or sets the purple switches.
        /// </summary>
        /// <value>The purple switches.</value>
        public int[] PurpleSwitches { get; set; }

        /// <summary>
        ///     Gets or sets the checkpoint y coordinate.
        /// </summary>
        /// <value>The checkpoint y coordinate.</value>
        public int CheckpointY { get; set; }

        /// <summary>
        ///     Gets or sets the checkpoint x coordinate.
        /// </summary>
        /// <value>The checkpoint x coordinate.</value>
        public int CheckpointX { get; set; }

        /// <summary>
        ///     Gets or sets the amount deaths.
        /// </summary>
        /// <value>The deaths.</value>
        public int Deaths { get; set; }

        /// <summary>
        ///     Gets or sets the amount of collected blue coins.
        /// </summary>
        /// <value>The blue coins.</value>
        public int BlueCoins { get; set; }

        /// <summary>
        ///     Gets or sets the amount of collected gold coins.
        /// </summary>
        /// <value>The gold coins.</value>
        public int GoldCoins { get; set; }

        /// <summary>
        ///     Gets or sets the speed x.
        /// </summary>
        /// <value>The speed x.</value>
        public double SpeedX { get; set; }

        /// <summary>
        ///     Gets or sets the speed y.
        /// </summary>
        /// <value>The speed y.</value>
        public double SpeedY { get; set; }

        /// <summary>
        ///     Gets the block x.
        /// </summary>
        /// <value>The block x.</value>
        public int BlockX
        {
            get { return WorldUtils.PosToBlock(this.X); }
        }

        /// <summary>
        ///     Gets the block y.
        /// </summary>
        /// <value>The block y.</value>
        public int BlockY
        {
            get { return WorldUtils.PosToBlock(this.Y); }
        }

        /// <summary>
        ///     Gets or sets the user coordinate x.
        /// </summary>
        /// <value>The user position x.</value>
        public double X { get; set; }

        /// <summary>
        ///     Gets or sets the user coordinate y.
        /// </summary>
        /// <value>The user position y.</value>
        public double Y { get; set; }
    }
}