using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to request add to crew.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class RequestAddToCrewSendMessage : SendMessage<RequestAddToCrewSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RequestAddToCrewSendMessage" /> class.
        /// </summary>
        /// <param name="crewId">The text.</param>
        public RequestAddToCrewSendMessage(string crewId)
        {
            this.CrewId = crewId;
        }

        /// <summary>
        ///     Gets or sets the crew identifer.
        /// </summary>
        /// <value>
        ///     The crew identifier.
        /// </value>
        public string CrewId { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("requestAddToCrew", this.CrewId);
        }
    }
}