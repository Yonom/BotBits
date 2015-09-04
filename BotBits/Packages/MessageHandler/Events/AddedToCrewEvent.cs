using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("addedToCrew")]
    public sealed class AddedToCrewEvent : ReceiveEvent<AddedToCrewEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AddedToCrewEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal AddedToCrewEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.CrewId = message.GetString(0);
            this.CrewName = message.GetString(1);
        }

        public string CrewName { get; set; }

        public string CrewId { get; set; }
    }
}