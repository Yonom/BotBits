using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change smiley.
    /// </summary>
    public sealed class SmileySendMessage : SendMessage<SmileySendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmileySendMessage" /> class.
        /// </summary>
        /// <param name="smiley">The face.</param>
        public SmileySendMessage(Smiley smiley)
        {
            this.Smiley = smiley;
        }

        /// <summary>
        ///     Gets or sets the face.
        /// </summary>
        /// <value>
        ///     The face.
        /// </value>
        public Smiley Smiley { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("smiley", (int)this.Smiley);
        }
    }
}