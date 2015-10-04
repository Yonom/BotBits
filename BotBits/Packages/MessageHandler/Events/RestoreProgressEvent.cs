using System.Linq;
using PlayerIOClient;

namespace BotBits.Events
{
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

        public Point[] BlueCoinPoints { get; set; }

        public Point[] GoldCoinPoints { get; set; }

        public int[] PurpleSwitches { get; set; }

        public int CheckpointY { get; set; }

        public int CheckpointX { get; set; }

        public int Deaths { get; set; }

        public int BlueCoins { get; set; }

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