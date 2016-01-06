using PlayerIOClient;

namespace BotBits.Events
{
    // NOTE: Internal to avoid confusion with Foreground/Background place

    /// <summary>
    ///     Occurs when a block is placed in the world.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("b")]
    internal sealed class BlockPlaceEvent : PlayerEvent<BlockPlaceEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BlockPlaceEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal BlockPlaceEvent(BotBitsClient client, Message message)
            : base(client, message, 4)
        {
            Layer = (Layer) message.GetInteger(0);
            X = message.GetInteger(1);
            Y = message.GetInteger(2);
            Id = message.GetInteger(3);
        }

        /// <summary>
        ///     Gets or sets the layer.
        /// </summary>
        /// <value>The layer.</value>
        public Layer Layer { get; set; }

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

        /// <summary>
        ///     Gets or sets the block id.
        /// </summary>
        /// <value>
        ///     The block id.
        /// </value>
        public int Id { get; set; }
    }
}