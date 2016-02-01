using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when world is reverted to last save using /loadlevel command.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("reset")]
    public sealed class LoadLevelEvent : ReceiveEvent<LoadLevelEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LoadLevelEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal LoadLevelEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}