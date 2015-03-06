using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("add")]
    public sealed class JoinEvent : PlayerEvent<JoinEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JoinEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal JoinEvent(BotBitsClient client, Message message)
            : base(client, message, create: true)
        {
            this.Username = message.GetString(1);
            this.Smiley = (Smiley)message.GetInteger(2);
            this.X = message.GetInteger(3);
            this.Y = message.GetInteger(4);
            this.God = message.GetBoolean(5);
            this.Mod = message.GetBoolean(6);
            this.HasChat = message.GetBoolean(7);
            this.Coins = message.GetInteger(8);
            this.BlueCoins = message.GetInteger(9);
            //this.PurpleSwitch = message.GetBoolean(10); TODO
            this.Friend = message.GetBoolean(10);
            this.ClubMember = message.GetBoolean(11);
            this.Guardian = message.GetBoolean(12);
        }

        /// <summary>
        ///     Gets or sets whether the user is in guardian mode or not.
        /// </summary>
        /// <value><c>true</c> if the player has activated guardian mode; otherwise, <c>false</c>.</value>
        public bool Guardian { get; set; }

        /// <summary>
        ///     Gets or sets the amount of yellow coins the player has.
        /// </summary>
        /// <value>The yellow coins.</value>
        public int Coins { get; set; }

        /// <summary>
        ///     Gets or sets the amount of blue coins the player has.
        /// </summary>
        /// <value>The blue coins.</value>
        public int BlueCoins { get; set; }

        /// <summary>
        ///     Gets or sets the smiley the player has.
        /// </summary>
        /// <value>The face.</value>
        public Smiley Smiley { get; set; }

        /// <summary>
        ///     Gets or sets whether this player may chat using the free-form chat box.
        /// </summary>
        /// <value><c>true</c> if this player has chat; otherwise, <c>false</c>.</value>
        public bool HasChat { get; set; }

        /// <summary>
        ///     Gets or sets whether this player is a club member.
        /// </summary>
        /// <value><c>true</c> if this player is a club member; otherwise, <c>false</c>.</value>
        public bool ClubMember { get; set; }

        /// <summary>
        ///     Gets or sets whether this player has activated god mode.
        /// </summary>
        /// <value><c>true</c> if this player is in god mode; otherwise, <c>false</c>.</value>
        public bool God { get; set; }

        /// <summary>
        ///     Gets or sets whether this player is a moderator.
        /// </summary>
        /// <value><c>true</c> if this player is a moderator; otherwise, <c>false</c>.</value>
        public bool Mod { get; set; }

        /// <summary>
        ///     Gets or sets whether this player is my friend or not.
        /// </summary>
        /// <value><c>true</c> if this player is my friend; otherwise, <c>false</c>.</value>
        public bool Friend { get; set; }

        /// <summary>
        ///     Gets or sets whether the player has toggled a purple switch.
        /// </summary>
        /// <value><c>true</c> if the player has toggled a purple switch; otherwise, <c>false</c>.</value>
        public bool PurpleSwitch { get; set; }

        /// <summary>
        ///     Gets or sets the username of the player.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets the x coordinate of the player.
        /// </summary>
        /// <value>The user position x.</value>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the y coordinate of the player.
        /// </summary>
        /// <value>The user position y.</value>
        public int Y { get; set; }

        /// <summary>
        ///     Gets the block x.
        /// </summary>
        /// <value>The block x.</value>
        public int BlockX
        {
            get { return WorldUtils.PosToBlock(this.X); }
        }

        /// <summary>
        ///     Gets the block y.
        /// </summary>
        /// <value>The block y.</value>
        public int BlockY
        {
            get { return WorldUtils.PosToBlock(this.Y); }
        }
    }
}