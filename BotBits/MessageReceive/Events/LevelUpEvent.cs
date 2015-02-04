using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("levelup")]
    public sealed class LevelUpEvent : PlayerEvent<LevelUpEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LevelUpEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal LevelUpEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.NewClass = (MagicClass)message.GetInteger(1);
        }

        /// <summary>
        ///     Gets or sets the new class.
        /// </summary>
        /// <value>The new class.</value>
        public MagicClass NewClass { get; set; }
    }
}