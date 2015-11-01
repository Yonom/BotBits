using PlayerIOClient;

namespace BotBits
{
    public interface IConnection
    {
        /// <summary>
        ///     Gets a value indicating whether this <see cref="IConnection" /> is connected.
        /// </summary>
        /// <value>
        ///     <c>true</c> if connected; otherwise, <c>false</c>.
        /// </value>
        bool Connected { get; }

        /// <summary>
        ///     Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Send(Message message);

        /// <summary>
        ///     Disconnects this instance.
        /// </summary>
        void Disconnect();

        /// <summary>
        ///     Occurs when a message is received.
        /// </summary>
        event MessageReceivedEventHandler OnMessage;

        /// <summary>
        ///     Occurs when this instance is disconnected.
        /// </summary>
        event DisconnectEventHandler OnDisconnect;
    }
}