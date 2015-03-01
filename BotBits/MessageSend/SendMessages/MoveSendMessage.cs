using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Move Send Event
    /// </summary>
    public sealed class MoveSendMessage : SendMessage<MoveSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MoveSendMessage" /> class.
        /// </summary>
        /// <param name="x">The x-coordinate of the position.</param>
        /// <param name="y">The y-coordinate of the position.</param>
        /// <param name="speedX">The horizontal speed.</param>
        /// <param name="speedY">The vertical speed.</param>
        /// <param name="modifierX">The horizontal speed modifier.</param>
        /// <param name="modifierY">The vertical speed modifier.</param>
        /// <param name="horizontal">The horizontal speed direction.</param>
        /// <param name="vertical">The vertical speed direction.</param>
        /// <param name="spaceDown">if set to <c>true</c> then spacebar is pressed.</param>
        public MoveSendMessage(int x, int y, double speedX, double speedY, double modifierX, double modifierY,
            double horizontal, double vertical, bool spaceDown)
        {
            this.X = x;
            this.Y = y;
            this.SpeedX = speedX;
            this.SpeedY = speedY;
            this.ModifierX = modifierX;
            this.ModifierY = modifierY;
            this.Horizontal = horizontal;
            this.Vertical = vertical;
            this.SpaceDown = spaceDown;
        }

        /// <summary>
        ///     Gets or sets the gravity multiplier.
        /// </summary>
        /// <value>
        ///     The gravity multiplier.
        /// </value>
        private double GravityMultiplier { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether spacebar is pressed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if spacebar is pressed; otherwise, <c>false</c>.
        /// </value>
        public bool SpaceDown { get; set; }

        /// <summary>
        ///     Gets or sets the horizontal speed direction.
        /// </summary>
        /// <value>
        ///     The horizontal speed direction.
        /// </value>
        public double Horizontal { get; set; }

        /// <summary>
        ///     Gets or sets the vertical speed direction.
        /// </summary>
        /// <value>
        ///     The vertical speed direction.
        /// </value>
        public double Vertical { get; set; }

        /// <summary>
        ///     Gets or sets the horizontal speed modifier.
        /// </summary>
        /// <value>
        ///     The horizontal speed modifier.
        /// </value>
        public double ModifierX { get; set; }

        /// <summary>
        ///     Gets or sets the vertical speed modifier.
        /// </summary>
        /// <value>
        ///     The vertical speed modifier.
        /// </value>
        public double ModifierY { get; set; }

        /// <summary>
        ///     Gets or sets the x-coordinate of the position.
        /// </summary>
        /// <value>
        ///     The x-coordinate of the position.
        /// </value>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the y-coordinate of the position.
        /// </summary>
        /// <value>
        ///     The y-coordinate of the position.
        /// </value>
        public int Y { get; set; }

        /// <summary>
        ///     Gets or sets the horizontal speed.
        /// </summary>
        /// <value>
        ///     The horizontal speed.
        /// </value>
        public double SpeedX { get; set; }

        /// <summary>
        ///     Gets or sets the vertical speed.
        /// </summary>
        /// <value>
        ///     The vertical speed.
        /// </value>
        public double SpeedY { get; set; }

        public override void SendIn(BotBitsClient client)
        {
            this.GravityMultiplier = Room.Of(client).GravityMultiplier;

            base.SendIn(client);
        }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("m", this.X, this.Y, this.SpeedX, this.SpeedY, this.ModifierX, this.ModifierY,
                this.Horizontal, this.Vertical, this.GravityMultiplier, this.SpaceDown);
        }
    }
}