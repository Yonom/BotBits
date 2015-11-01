using PlayerIOClient;

namespace BotBits.SendMessages
{
    public sealed class AuraSendMessage : RoomTokenSendMessage<AuraSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AuraSendMessage" /> class.
        /// </summary>
        /// <param name="aura">The aura.</param>
        public AuraSendMessage(Aura aura)
        {
            this.Aura = aura;
        }

        /// <summary>
        ///     Gets or sets your aura.
        /// </summary>
        /// <value>
        ///     The aura.
        /// </value>
        public Aura Aura { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create(this.RoomToken + "a", this.Aura);
        }
    }
}