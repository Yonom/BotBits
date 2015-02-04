using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("givewitch")]
    public sealed class GiveWitchEvent : ReceiveEvent<GiveWitchEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GiveWitchEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal GiveWitchEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}