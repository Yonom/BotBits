using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when someone joins world.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
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
            this.ConnectUserId = message.GetString(2);
            this.Smiley = (Smiley)message.GetInteger(3);
            this.X = message.GetDouble(4);
            this.Y = message.GetDouble(5);
            this.GodMode = message.GetBoolean(6);
            this.AdminMode = message.GetBoolean(7);
            this.HasChat = message.GetBoolean(8);
            this.Coins = message.GetInteger(9);
            this.BlueCoins = message.GetInteger(10);
            this.Deaths = message.GetInteger(11);
            this.Friend = message.GetBoolean(12);
            this.GoldMember = message.GetBoolean(13);
            this.GoldBorder = message.GetBoolean(14);
            this.Mod = message.GetBoolean(15);
            this.Team = (Team)message.GetInt(16);
            this.AuraShape = (AuraShape)message.GetInt(17);
            this.AuraColor = (AuraColor)message.GetInt(18);
            this.ChatColor = message.GetUInt(19);
            this.Badge = message.GetBadge(20);
            this.CrewMember = message.GetBoolean(21);
            this.PurpleSwitches = VarintHelper.ToInt32Array(message.GetByteArray(22));
            this.StaffAuraOffset = message.GetInt(23);

            if (message.Count > 24)
            {
                this.HasEditRights = message.GetBoolean(24);
            }
        }

        public int StaffAuraOffset { get; set; }

        public bool GoldBorder { get; set; }

        public bool? HasEditRights { get; set; }

        public AuraColor AuraColor { get; set; }

        /// <summary>
        ///     Gets or sets the amount of deaths.
        /// </summary>
        /// <value>The deaths.</value>
        public int Deaths { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether player is crew member.
        /// </summary>
        /// <value><c>true</c> if player is crew member; otherwise, <c>false</c>.</value>
        public bool CrewMember { get; set; }

        /// <summary>
        ///     Gets or sets the badge.
        /// </summary>
        /// <value>The badge.</value>
        public Badge Badge { get; set; }

        /// <summary>
        ///     Gets or sets the connect user identifier.
        /// </summary>
        /// <value>The connect user identifier.</value>
        public string ConnectUserId { get; set; }

        /// <summary>
        ///     Gets or sets the aura.
        /// </summary>
        /// <value>
        ///     The aura.
        /// </value>
        public AuraShape AuraShape { get; set; }

        /// <summary>
        ///     Gets or sets the team.
        /// </summary>
        /// <value>
        ///     The team.
        /// </value>
        public Team Team { get; set; }

        /// <summary>
        ///     Gets or sets the color of the chat.
        /// </summary>
        /// <value>
        ///     The color of the chat.
        /// </value>
        public uint ChatColor { get; set; }

        /// <summary>
        ///     Gets or sets whether the user is in admin mode or not.
        /// </summary>
        /// <value><c>true</c> if the player has activated admin mode; otherwise, <c>false</c>.</value>
        public bool AdminMode { get; set; }

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
        public bool GoldMember { get; set; }

        /// <summary>
        ///     Gets or sets whether this player has activated god mode.
        /// </summary>
        /// <value><c>true</c> if this player is in god mode; otherwise, <c>false</c>.</value>
        public bool GodMode { get; set; }

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
        public int[] PurpleSwitches { get; set; }

        /// <summary>
        ///     Gets or sets the username of the player.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets the x coordinate of the player.
        /// </summary>
        /// <value>The user position x.</value>
        public double X { get; set; }

        /// <summary>
        ///     Gets or sets the y coordinate of the player.
        /// </summary>
        /// <value>The user position y.</value>
        public double Y { get; set; }

        /// <summary>
        ///     Gets the block x.
        /// </summary>
        /// <value>The block x.</value>
        public int BlockX => WorldUtils.PosToBlock(this.X);

        /// <summary>
        ///     Gets the block y.
        /// </summary>
        /// <value>The block y.</value>
        public int BlockY => WorldUtils.PosToBlock(this.Y);
    }
}