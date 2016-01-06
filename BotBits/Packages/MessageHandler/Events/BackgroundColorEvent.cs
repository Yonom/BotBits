using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when background color of the world is changed.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("backgroundColor")]
    public sealed class BackgroundColorEvent : ReceiveEvent<BackgroundColorEvent>
    {
        internal BackgroundColorEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            BackgroundColor = message.GetUInt(0);
        }

        /// <summary>
        ///     Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public uint BackgroundColor { get; set; }
    }
}