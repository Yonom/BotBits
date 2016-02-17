using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change dis/allow spectating in the world.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class SetAllowSpectatingSendMessage : SendMessage<SetAllowSpectatingSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SetAllowSpectatingSendMessage" /> class.
        /// </summary>
        /// <param name="allow">if set to <c>true</c>, spectating is allowed.</param>
        public SetAllowSpectatingSendMessage(bool allow)
        {
            this.Allow = allow;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether spectating is allowed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if allowed; otherwise, <c>false</c>.
        /// </value>
        public bool Allow { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("setAllowSpectating", this.Allow);
        }
    }
}