using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("backgroundColor")]
    public sealed class BackgroundColorEvent : ReceiveEvent<BackgroundColorEvent>
    {
        internal BackgroundColorEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.BackgroundColor = message.GetUInt(0);
        }

        public uint BackgroundColor { get; set; }
    }
}