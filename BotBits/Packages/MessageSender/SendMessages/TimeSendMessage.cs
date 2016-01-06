using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to request time response.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class TimeSendMessage : SendMessage<TimeSendMessage>
    {
        public TimeSendMessage(double data)
        {
            this.Data = data;
        }

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>
        ///     The data.
        /// </value>
        public double Data { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("time", this.Data);
        }
    }
}