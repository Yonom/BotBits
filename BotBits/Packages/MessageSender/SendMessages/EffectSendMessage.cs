using PlayerIOClient;

namespace BotBits.SendMessages
{
    public sealed class EffectSendMessage : SendMessage<EffectSendMessage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EffectSendMessage" /> class.
        /// </summary>
        /// <param name="effect">The effect.</param>
        /// <param name="activate">if set to <c>true</c> the effect will be activated.</param>
        /// <param name="y">The y.</param>
        /// <param name="x">The x.</param>
        public EffectSendMessage(Effect effect, bool activate, int y, int x)
        {
            this.Effect = effect;
            this.Activate = activate;
            this.Y = y;
            this.X = x;
        }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("effect", this.X, this.Y, (int)this.Effect, this.Activate);
        }

        /// <summary>
        /// Gets or sets the effect.
        /// </summary>
        /// <value>
        /// The effect.
        /// </value>
        public Effect Effect { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this effect is activated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if activated; otherwise, <c>false</c>.
        /// </value>
        public bool Activate { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public int X { get; set; }
    }
}