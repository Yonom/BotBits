using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("br")]
    public sealed class RotatablePlaceEvent : ReceiveEvent<RotatablePlaceEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RotatablePlaceEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal RotatablePlaceEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.X = message.GetInteger(0);
            this.Y = message.GetInteger(1);
            this.Id = message.GetInteger(2);
            this.Rotation = message.GetUInt(3);
        }

        /// <summary>
        ///     Gets or sets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        public uint Rotation { get; set; }

        /// <summary>
        ///     Gets or sets the block id.
        /// </summary>
        /// <value>
        ///     The block id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the position x.
        /// </summary>
        /// <value>The position x.</value>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the position y.
        /// </summary>
        /// <value>The position y.</value>
        public int Y { get; set; }
    }
}