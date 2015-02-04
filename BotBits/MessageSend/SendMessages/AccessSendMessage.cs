using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Access Send Event.
    /// </summary>
    public sealed class AccessSendMessage : SendMessage<AccessSendMessage>
    {
        public AccessSendMessage(string editKey)
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
            return Message.Create("access", this.EditKey);
        }
    }
}