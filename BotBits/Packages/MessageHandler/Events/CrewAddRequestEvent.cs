using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("crewAddRequest")]
    public sealed class CrewAddRequestEvent : ReceiveEvent<CrewAddRequestEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CrewAddRequestEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal CrewAddRequestEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Requester = message.GetString(0);
            this.CrewName = message.GetString(1);
        }

        public string CrewName { get; set; }

        public string Requester { get; set; }
    }
}