using PlayerIOClient;

namespace BotBits.SendMessages
{
    public sealed class SetZombieLimitSendMessage : SendMessage<SetZombieLimitSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SetZombieLimitSendMessage" /> class.
        /// </summary>
        /// <param name="limit">The limit.</param>
        public SetZombieLimitSendMessage(int limit)
        {
            this.Limit = limit;
        }

        /// <summary>
        ///     Gets or sets the limit.
        /// </summary>
        /// <value>
        ///     The limit.
        /// </value>
        public int Limit { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("setZombieLimit", this.Limit);
        }
    }
}