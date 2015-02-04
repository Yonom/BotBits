using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("clear")]
    public sealed class ClearEvent : ReceiveEvent<ClearEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ClearEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal ClearEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.RoomWidth = message.GetInteger(0);
            this.RoomHeight = message.GetInteger(1);
            this.BorderBlock = (Foreground)message.GetInteger(2);
            this.FillBlock = (Foreground)message.GetInteger(3);
        }

        /// <summary>
        ///     Gets or sets the fill block.
        /// </summary>
        /// <value>The fill block.</value>
        public Foreground FillBlock { get; set; }

        /// <summary>
        ///     Gets or sets the border block.
        /// </summary>
        /// <value>The border block.</value>
        public Foreground BorderBlock { get; set; }

        /// <summary>
        ///     Gets or sets the height of the room.
        /// </summary>
        /// <value>The height of the room.</value>
        public int RoomHeight { get; set; }

        /// <summary>
        ///     Gets or sets the width of the room.
        /// </summary>
        /// <value>The width of the room.</value>
        public int RoomWidth { get; set; }
    }
}