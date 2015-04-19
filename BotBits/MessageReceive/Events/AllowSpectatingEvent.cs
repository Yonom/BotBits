using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("allowSpectating")]
    public sealed class AllowSpectatingEvent : ReceiveEvent<AllowSpectatingEvent>
    {
        internal AllowSpectatingEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Allow = message.GetBoolean(0);
        }

        public bool Allow { get; set; }
    }
}