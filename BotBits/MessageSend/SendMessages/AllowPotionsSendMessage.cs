using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Allow Potions Send Event
    /// </summary>
    public sealed class AllowPotionsSendMessage : SendMessage<AllowPotionsSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AllowPotionsSendMessage" /> class.
        /// </summary>
        /// <param name="allowed">if set to <c>true</c> then potions are allowed.</param>
        public AllowPotionsSendMessage(bool allowed)
        {
            this.Allowed = allowed;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether potions are allowed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if potions are allowed; otherwise, <c>false</c>.
        /// </value>
        public bool Allowed { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("allowpotions", this.Allowed);
        }
    }
}