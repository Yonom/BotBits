using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("crewAddRequestFailed")]
    public sealed class CrewAddRequestFailedEvent : ReceiveEvent<CrewAddRequestFailedEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CrewAddRequestFailedEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal CrewAddRequestFailedEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Reason = message.GetString(0);
        }

        public string Reason { get; set; }
    }
}