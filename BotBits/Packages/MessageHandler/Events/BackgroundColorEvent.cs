using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("backgroundColor")]
    public sealed class BackgroundColorEvent : ReceiveEvent<BackgroundColorEvent>
    {
        internal BackgroundColorEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Enabled = message.GetBoolean(0);
            this.BackgroundColor = message.GetUInt(1);
        }

        public uint BackgroundColor { get; set; }
        public bool Enabled { get; set; }
    }
}