using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("givewizard")]
    public sealed class GiveWizardEvent : ReceiveEvent<GiveWizardEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GiveWizardEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal GiveWizardEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}