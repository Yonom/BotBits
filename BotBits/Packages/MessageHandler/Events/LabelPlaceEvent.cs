using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("lb")]
    public sealed class LabelPlaceEvent : PlayerEvent<LabelPlaceEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LabelPlaceEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal LabelPlaceEvent(BotBitsClient client, Message message)
            : base(client, message, 5)
        {
            this.X = message.GetInteger(0);
            this.Y = message.GetInteger(1);
            this.Id = message.GetInteger(2);
            this.Text = message.GetString(3);
            this.TextColor = message.GetString(4);
        }

        /// <summary>
        ///     Gets or sets the color of the text.
        /// </summary>
        /// <value>
        ///     The color of the text.
        /// </value>
        public string TextColor { get; set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        ///     Gets or sets the block id.
        /// </summary>
        /// <value>
        ///     The block id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the coordinate x.
        /// </summary>
        /// <value>The coordinate x.</value>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the coordinate y.
        /// </summary>
        /// <value>The coordinate y.</value>
        public int Y { get; set; }
    }
}