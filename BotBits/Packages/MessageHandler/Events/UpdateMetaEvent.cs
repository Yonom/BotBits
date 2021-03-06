using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when world metadata is updated.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("updatemeta")]
    public sealed class UpdateMetaEvent : ReceiveEvent<UpdateMetaEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UpdateMetaEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal UpdateMetaEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.OwnerUsername = message.GetString(0);
            this.WorldName = message.GetString(1);
            this.Plays = message.GetInteger(2);
            this.Favorites = message.GetInteger(3);
            this.Likes = message.GetInteger(4);
        }

        /// <summary>
        ///     Gets or sets the current woots of the world.
        /// </summary>
        /// <value>The current woots.</value>
        public int Favorites { get; set; }

        /// <summary>
        ///     Gets or sets the owner username of the world.
        /// </summary>
        /// <value>The owner username.</value>
        public string OwnerUsername { get; set; }

        /// <summary>
        ///     Gets or sets the plays of the world.
        /// </summary>
        /// <value>The plays.</value>
        public int Plays { get; set; }

        /// <summary>
        ///     Gets or sets the total woots of the world.
        /// </summary>
        /// <value>The total woots.</value>
        public int Likes { get; set; }

        /// <summary>
        ///     Gets or sets the name of the world.
        /// </summary>
        /// <value>The name of the world.</value>
        public string WorldName { get; set; }
    }
}