using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to activate an effect.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class EffectSendMessage : SendMessage<EffectSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EffectSendMessage" /> class.
        /// </summary>
        /// <param name="effect">The effect.</param>
        /// <param name="y">The y.</param>
        /// <param name="x">The x.</param>
        public EffectSendMessage(Effect effect, int y, int x)
        {
            this.Effect = effect;
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
            return Message.Create("effect", this.X, this.Y, (int)this.Effect);
        }
    }
}