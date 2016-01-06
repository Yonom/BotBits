using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when an attempt to request adding world to crew didn't succeed.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
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
            Reason = message.GetString(0);
        }

        /// <summary>
        ///     Gets or sets the reason of the failure.
        /// </summary>
        /// <value>The reason.</value>
        public string Reason { get; set; }
    }
}