using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("aura")]
    public sealed class AuraEvent : PlayerEvent<AuraEvent>
    {
        internal AuraEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Aura = (Aura) message.GetInt(1);
        }

        public Aura Aura { get; set; }
    }
}