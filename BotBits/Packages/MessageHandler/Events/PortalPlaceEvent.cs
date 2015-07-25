using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("pt")]
    public sealed class PortalPlaceEvent : PlayerEvent<PortalPlaceEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PortalPlaceEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal PortalPlaceEvent(BotBitsClient client, Message message)
            : base(client, message, 6)
        {
            this.X = message.GetInteger(0);
            this.Y = message.GetInteger(1);
            this.Id = message.GetInteger(2);
            this.PortalRotation = (Morph.Id)message.GetUInt(3);
            this.PortalId = message.GetUInt(4);
            this.PortalTarget = message.GetUInt(5);
        }

        /// <summary>
        ///     Gets or sets the portal identifier.
        /// </summary>
        /// <value>The portal identifier.</value>
        public uint PortalId { get; set; }

        /// <summary>
        ///     Gets or sets the portal rotation.
        /// </summary>
        /// <value>The portal rotation.</value>
        public Morph.Id PortalRotation { get; set; }

        /// <summary>
        ///     Gets or sets the portal target.
        /// </summary>
        /// <value>The portal target.</value>
        public uint PortalTarget { get; set; }

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