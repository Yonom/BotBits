using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Potion Send Event
    /// </summary>
    public sealed class PotionSendMessage : RoomTokenSendMessage<PotionSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PotionSendMessage" /> class.
        /// </summary>
        /// <param name="potion">The potion.</param>
        public PotionSendMessage(Potion potion)
        {
            this.Potion = potion;
        }

        /// <summary>
        ///     Gets or sets the potion.
        /// </summary>
        /// <value>
        ///     The potion.
        /// </value>
        public Potion Potion { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create(this.RoomToken + "p", (int)this.Potion);
        }
    }
}