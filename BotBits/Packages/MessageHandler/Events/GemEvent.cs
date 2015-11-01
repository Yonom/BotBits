using System;
using PlayerIOClient;

namespace BotBits.Events
{
    [Obsolete(
        "This is new functionality not available in the game. There are no gurantees about the availablity of this API in future versions of BotBits."
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