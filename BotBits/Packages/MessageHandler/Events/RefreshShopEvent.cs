using System;
using PlayerIOClient;

namespace BotBits.Events
{
    [Obsolete(
        "This functionality is not available in the game. There are no guarantees about the availability of this API in future versions of BotBits."
        )]
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