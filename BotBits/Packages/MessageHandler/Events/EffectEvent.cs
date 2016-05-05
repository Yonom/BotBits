using System;
using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player gains or looses an effect.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("effect")]
    public sealed class EffectEvent : PlayerEvent<EffectEvent>
    {
        internal EffectEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Effect = (Effect)message.GetInt(1);
            this.Enabled = message.GetBoolean(2);

            if (message.Count < 4) return;
            this.TimeLeft = TimeSpan.FromSeconds(message.GetDouble(3));
            if (message.Count < 5) return;
            this.Duration = TimeSpan.FromSeconds(message.GetInt(4));
        }

        /// <summary>
        ///     Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        public TimeSpan Duration { get; set; }

        /// <summary>
        ///     Gets or sets the time left before the effect expires.
        /// </summary>
        /// <value>The time left before the effect expires..</value>
        public TimeSpan TimeLeft { get; set; }

        /// <summary>
        ///     Gets a value indicating whether effect can expire
        /// </summary>
        /// <value><c>true</c> if effect can expire; otherwise, <c>false</c>.</value>
        public bool Expires => this.Duration.Ticks != 0;

        /// <summary>
        ///     Gets or sets a value indicating whether effect is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the effect.
        /// </summary>
        /// <value>The effect.</value>
        public Effect Effect { get; set; }
    }
}