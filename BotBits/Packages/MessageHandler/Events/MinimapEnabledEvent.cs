using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("minimapEnabled")]
    public sealed class MinimapEnabledEvent : ReceiveEvent<MinimapEnabledEvent>
    {
        internal MinimapEnabledEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Enabled = message.GetBoolean(0);
        }

        public bool Enabled { get; set; }
    }
}