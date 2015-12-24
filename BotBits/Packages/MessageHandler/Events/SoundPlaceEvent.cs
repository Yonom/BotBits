using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("bs")]
    public sealed class SoundPlaceEvent : PlayerEvent<SoundPlaceEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SoundPlaceEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal SoundPlaceEvent(BotBitsClient client, Message message)
            : base(client, message, 4)
        {
            this.X = message.GetInteger(0);
            this.Y = message.GetInteger(1);
            this.Id = message.GetInteger(2);
            this.SoundId = message.GetInt(3);
        }

        /// <summary>
        ///     Gets or sets the sound identifier.
        /// </summary>
        /// <value>The sound identifier.</value>
        public int SoundId { get; set; }

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