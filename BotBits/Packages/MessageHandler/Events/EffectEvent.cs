using System;
using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("effect")]
    public sealed class EffectEvent : PlayerEvent<EffectEvent>
    {
        internal EffectEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Effect = (Effect)message.GetInt(1);
            this.Enabled = message.GetBoolean(2);

            if (message.Count < 5) return;
            this.TimeLeft = TimeSpan.FromSeconds(message.GetDouble(3));
            this.Duration = TimeSpan.FromSeconds(message.GetInt(4));
        }

        public TimeSpan Duration { get; set; }

        public TimeSpan TimeLeft { get; set; }

        public bool Expires { get { return this.Duration.Ticks != 0; } }

        public bool Enabled { get; set; }

        public Effect Effect { get; set; }
    }
}
