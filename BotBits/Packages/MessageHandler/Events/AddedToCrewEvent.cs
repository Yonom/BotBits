using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when world was successfully added to crew.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("addedToCrew")]
    public sealed class AddedToCrewEvent : ReceiveEvent<AddedToCrewEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AddedToCrewEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal AddedToCrewEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.CrewId = message.GetString(0);
            this.CrewName = message.GetString(1);
        }

        /// <summary>
        ///     Gets or sets the name of the crew.
        /// </summary>
        /// <value>The name of the crew.</value>
        public string CrewName { get; set; }

        /// <summary>
        ///     Gets or sets the crew identifier.
        /// </summary>
        /// <value>The crew identifier.</value>
        public string CrewId { get; set; }
    }
}