using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("aura")]
    public sealed class AuraEvent : PlayerEvent<AuraEvent>
    {
        internal AuraEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.AuraShape = (AuraShape) message.GetInt(1);
            this.AuraColor = (AuraColor)message.GetInt(2);
        }

        public AuraShape AuraShape { get; set; }

        public AuraColor AuraColor { get; set; }
    }
}