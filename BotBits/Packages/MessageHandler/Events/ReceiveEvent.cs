using System.ComponentModel;
using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when an EE message is received.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public abstract class ReceiveEvent<T> : Event<T> where T : ReceiveEvent<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ReceiveEvent{T}" /> class.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message">The message.</param>
        internal ReceiveEvent(BotBitsClient client, Message message)
        {
            this.PlayerIOMessage = message;
        }

        /// <summary>
        ///     Gets the player io message.
        /// </summary>
        /// <value>The player io message.</value>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public Message PlayerIOMessage { get; }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.GetType().Name + this.PlayerIOMessage;
        }
    }
}