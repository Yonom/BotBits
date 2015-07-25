using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("refreshshop")]
    public sealed class RefreshShopEvent : ReceiveEvent<RefreshShopEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RefreshShopEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal RefreshShopEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}