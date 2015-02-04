using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("givewizard2")]
    public sealed class GiveFireWizardEvent : ReceiveEvent<GiveFireWizardEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GiveFireWizardEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal GiveFireWizardEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}