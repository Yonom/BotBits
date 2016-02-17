using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player is teleported to another location.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("teleport")]
    public sealed class TeleportEvent : PlayerEvent<TeleportEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TeleportEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal TeleportEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.X = message.GetInteger(1);
            this.Y = message.GetInteger(2);
        }

        /// <summary>
        ///     Gets the block x.
        /// </summary>
        /// <value>The block x.</value>
        public int BlockX
        {
            get { return this.X + 8 >> 4; }
        }

        /// <summary>
        ///     Gets the block y.
        /// </summary>
        /// <value>The block y.</value>
        public int BlockY
        {
            get { return this.Y + 8 >> 4; }
        }

        /// <summary>
        ///     Gets or sets the user coordinate x.
        /// </summary>
        /// <value>The user position x.</value>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the user coordinate y.
        /// </summary>
        /// <value>The user position y.</value>
        public int Y { get; set; }
    }
}