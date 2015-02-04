using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Touch User Send Event
    /// </summary>
    public sealed class TouchUserSendMessage : SendMessage<TouchUserSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TouchUserSendMessage" /> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="reason">The reason (transferred potion).</param>
        public TouchUserSendMessage(int userId, Potion reason)
        {
            this.UserId = userId;
            this.Reason = reason;
        }

        /// <summary>
        ///     Gets or sets the reason (transferred potion).
        /// </summary>
        /// <value>
        ///     The reason (transferred potion).
        /// </value>
        public Potion Reason { get; set; }

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>
        ///     The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("touch", this.UserId, this.Reason);
        }
    }
}