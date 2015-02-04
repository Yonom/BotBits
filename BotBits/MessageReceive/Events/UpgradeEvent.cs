using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when the server version has increased.
    /// </summary>
    [ReceiveEvent("upgrade")]
    public sealed class UpgradeEvent : ReceiveEvent<UpgradeEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UpgradeEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal UpgradeEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}