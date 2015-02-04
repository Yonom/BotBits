using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player gives the world a woot.
    /// </summary>
    [ReceiveEvent("wu")]
    public sealed class WootUpEvent : PlayerEvent<WootUpEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WootUpEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal WootUpEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}