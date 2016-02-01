using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to touch other player transferring effects.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class TouchUserSendMessage : SendMessage<TouchUserSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TouchUserSendMessage" /> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="effect">The effect being transferred.</param>
        public TouchUserSendMessage(int userId, Effect effect)
        {
            this.UserId = userId;
            this.Effect = effect;
        }

        /// <summary>
        ///     Gets or sets the reason (transferred potion).
        /// </summary>
        /// <value>
        ///     The reason (transferred potion).
        /// </value>
        public Effect Effect { get; set; }

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
            return Message.Create("touch", this.UserId, (int) this.Effect);
        }
    }
}