using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("toggleGod")]
    public sealed class AllowToggleGodEvent : PlayerEvent<AllowToggleGodEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AllowToggleGodEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal AllowToggleGodEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.AllowToggle = message.GetBoolean(1);
        }

        public bool AllowToggle { get; set; }
    }
}