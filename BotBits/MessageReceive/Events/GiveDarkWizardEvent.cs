using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("givedarkwizard")]
    public sealed class GiveDarkWizardEvent : ReceiveEvent<GiveDarkWizardEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GiveDarkWizardEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal GiveDarkWizardEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}