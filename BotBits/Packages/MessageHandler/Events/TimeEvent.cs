using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("time")]
    public sealed class TimeEvent : ReceiveEvent<TimeEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TimeEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal TimeEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Data = message.GetDouble(0);
            this.Time = message.GetDouble(0);
        }

        public double Time { get; set; }
        public double Data { get; set; }
    }
}