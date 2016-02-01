using System;
using PlayerIOClient;

namespace BotBits.Events
{
    [Obsolete(
        "This functionality is not available in the game. There are no guarantees about the availability of this API in future versions of BotBits."
        )]
    [ReceiveEvent("gem")]
    public sealed class GemEvent : PlayerEvent<GemEvent>
    {
        internal GemEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}