using System;
using PlayerIOClient;

namespace BotBits.SendMessages
{
    public sealed class TimedEffectSendMessage : SendMessage<TimedEffectSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TimedEffectSendMessage" /> class.
        /// </summary>
        /// <param name="effect">The effect.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="y">The y.</param>
        /// <param name="x">The x.</param>
        public TimedEffectSendMessage(Effect effect, TimeSpan duration, int y, int x)
        {
            this.Effect = effect;
            this.Duration = (int) duration.TotalSeconds;
            this.Y = y;
            this.X = x;
        }

        /// <summary>
        ///     Gets or sets the effect.
        /// </summary>
        /// <value>
        ///     The effect.
        /// </value>
        public Effect Effect { get; set; }

        /// <summary>
        ///     Gets or sets the duration.
        /// </summary>
        /// <value>
        ///     The duration.
        /// </value>
        public int Duration { get; set; }

        /// <summary>
        ///     Gets or sets the y.
        /// </summary>
        /// <value>
        ///     The y.
        /// </value>
        public int Y { get; set; }

        /// <summary>
        ///     Gets or sets the x.
        /// </summary>
        /// <value>
        ///     The x.
        /// </value>
        public int X { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("timedeffect", this.X, this.Y, (int) this.Effect, this.Duration);
        }
    }
}