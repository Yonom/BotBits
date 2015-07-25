using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Raised when a received PlayerIOMessage could not be handled by BotBits.
    /// </summary>
    public sealed class UnknownMessageEvent : ReceiveEvent<UnknownMessageEvent>
    {
        internal UnknownMessageEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}