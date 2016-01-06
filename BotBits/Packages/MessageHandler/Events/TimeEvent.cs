using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs as a response to the "time" message.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
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
            Data = message.GetDouble(0);
            Time = message.GetDouble(0);
        }

        public double Time { get; set; }
        public double Data { get; set; }
    }
}