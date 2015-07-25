using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("mod")]
    public sealed class ModModeEvent : PlayerEvent<ModModeEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ModModeEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal ModModeEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Mod = message.GetBoolean(1);
        }

        public bool Mod { get; set; }
    }
}