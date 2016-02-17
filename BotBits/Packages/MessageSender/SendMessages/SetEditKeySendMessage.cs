using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change edit key.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class SetEditKeySendMessage : SendMessage<SetEditKeySendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SetEditKeySendMessage" /> class.
        /// </summary>
        /// <param name="editKey">The edit key.</param>
        public SetEditKeySendMessage(string editKey)
        {
            this.EditKey = editKey;
        }

        /// <summary>
        ///     Gets or sets the edit key.
        /// </summary>
        /// <value>
        ///     The edit key.
        /// </value>
        public string EditKey { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("key", this.EditKey);
        }
    }
}