using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Show Purple Send Event
    /// </summary>
    public sealed class PurpleSwitchSendMessage : SendMessage<PurpleSwitchSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PurpleSwitchSendMessage" /> class.
        /// </summary>
        /// <param name="show">whether the switch is enabled (purple gates are solid)</param>
        public PurpleSwitchSendMessage(bool show)
        {
            this.Show = show;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this switch is enabled (purple gates are solid).
        /// </summary>
        /// <value>
        ///     <c>true</c> if the switch is enabled (purple gates are solid); otherwise, <c>false</c>.
        /// </value>
        public bool Show { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("sp", this.Show);
        }
    }
}