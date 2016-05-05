using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when someone places morphable block.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("br")]
    public sealed class MorphablePlaceEvent : PlayerEvent<MorphablePlaceEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MorphablePlaceEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal MorphablePlaceEvent(BotBitsClient client, Message message)
            : base(client, message, 5)
        {
            this.X = message.GetInteger(0);
            this.Y = message.GetInteger(1);
            this.Id = message.GetInteger(2);
            this.Rotation = message.GetUInt(3);
            this.Layer = (Layer)message.GetUInt(4);
        }

        /// <summary>
        ///     Gets or sets the layer.
        /// </summary>
        /// <value>
        ///     The layer.
        /// </value>
        public Layer Layer { get; set; }

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