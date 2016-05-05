using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change crew world status.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class SetStatusSendMessage : SendMessage<SetStatusSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SetStatusSendMessage" /> class.
        /// </summary>
        /// <param name="status">if set to <c>true</c>, spectating is allowed.</param>
        public SetStatusSendMessage(WorldStatus status)
        {
            this.Status = status;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether spectating is allowed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if allowed; otherwise, <c>false</c>.
        /// </value>
        public WorldStatus Status { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("setStatus", (int)this.Status);
        }
    }
}