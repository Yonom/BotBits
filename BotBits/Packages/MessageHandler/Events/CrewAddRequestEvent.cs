using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player requests to add world to crew.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("crewAddRequest")]
    public sealed class CrewAddRequestEvent : ReceiveEvent<CrewAddRequestEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CrewAddRequestEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal CrewAddRequestEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Requester = message.GetString(0);
            this.CrewName = message.GetString(1);
        }

        /// <summary>
        ///     Gets or sets the name of the crew to which they want to add the world.
        /// </summary>
        /// <value>The name of the crew.</value>
        public string CrewName { get; set; }

        /// <summary>
        ///     Gets or sets the username of the requester.
        /// </summary>
        /// <value>The requester.</value>
        public string Requester { get; set; }
    }
}