using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("givegrinch")]
    public sealed class GiveGrinchEvent : ReceiveEvent<GiveGrinchEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GiveGrinchEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal GiveGrinchEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}