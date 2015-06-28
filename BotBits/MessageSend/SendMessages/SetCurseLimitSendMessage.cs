using PlayerIOClient;

namespace BotBits.SendMessages
{
    public sealed class SetCurseLimitSendMessage : SendMessage<SetCurseLimitSendMessage>
    {
        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        public int Limit { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="SetCurseLimitSendMessage" /> class.
        /// </summary>
        /// <param name="limit">The limit.</param>
        public SetCurseLimitSendMessage(int limit)
        {
            this.Limit = limit;
        }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("setCurseLimit", this.Limit);
        }
    }
}