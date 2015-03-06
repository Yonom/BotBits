using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when the player initially joins the room. Contains world information such as title and world content.
    /// </summary>
    [ReceiveEvent("init")]
    public sealed class InitEvent : PlayerEvent<InitEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InitEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal InitEvent(BotBitsClient client, Message message)
            : base(client, message, 6, true)
        {
            this.Owner = message.GetString(0);
            this.WorldName = message.GetString(1);
            this.Plays = message.GetInteger(2);
            this.CurrentWoots = message.GetInteger(3);
            this.TotalWoots = message.GetInteger(4);
            this.EncryptedToken = message.GetString(5);
            // 6: UserId
            this.SpawnX = message.GetInteger(7);
            this.SpawnY = message.GetInteger(8);
            this.Username = message.GetString(9);
            this.CanEdit = message.GetBoolean(10);
            this.IsOwner = message.GetBoolean(11);
            this.RoomWidth = message.GetInteger(12);
            this.RoomHeight = message.GetInteger(13);
            this.TutorialRoom = message.GetBoolean(14);
            this.GravityMultiplier = message.GetDouble(15);
            this.AllowPotions = message.GetBoolean(16);
            this.BackgroundColor = message.GetUInt(17);
            this.Visible = message.GetBoolean(18);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="InitEvent"/> is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>
        /// The color of the background.
        /// </value>
        public uint BackgroundColor { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the world has potions allowed.
        /// </summary>
        /// <value><c>true</c> if [allow potions]; otherwise, <c>false</c>.</value>
        public bool AllowPotions { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this player is allowed to edit.
        /// </summary>
        /// <value><c>true</c> if this instance can edit; otherwise, <c>false</c>.</value>
        public bool CanEdit { get; set; }

        /// <summary>
        ///     Gets or sets the encryption option of the world.
        /// </summary>
        /// <value>The encryption.</value>
        public string EncryptedToken { get; set; }

        /// <summary>
        ///     Gets or sets the gravity of the world.
        /// </summary>
        /// <value>The gravity.</value>
        public double GravityMultiplier { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this player owns the world.
        /// </summary>
        /// <value><c>true</c> if this player is the owner; otherwise, <c>false</c>.</value>
        public bool IsOwner { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this world is a tutorial world.
        /// </summary>
        /// <value><c>true</c> if this world is a tutorial world; otherwise, <c>false</c>.</value>
        public bool TutorialRoom { get; set; }

        /// <summary>
        ///     Gets or sets the width of the world.
        /// </summary>
        /// <value>The width of the room.</value>
        public int RoomWidth { get; set; }

        /// <summary>
        ///     Gets or sets the height of the world.
        /// </summary>
        /// <value>The height of the room.</value>
        public int RoomHeight { get; set; }

        /// <summary>
        ///     Gets or sets the spawn x coordinate.
        /// </summary>
        /// <value>The spawn x.</value>
        public int SpawnX { get; set; }

        /// <summary>
        ///     Gets or sets the spawn y coordinate.
        /// </summary>
        /// <value>The spawn y.</value>
        public int SpawnY { get; set; }

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets the current woots of the world.
        /// </summary>
        /// <value>The current woots.</value>
        public int CurrentWoots { get; set; }

        /// <summary>
        ///     Gets or sets the owner username of the world.
        /// </summary>
        /// <value>The owner username.</value>
        public string Owner { get; set; }

        /// <summary>
        ///     Gets or sets the plays of the world.
        /// </summary>
        /// <value>The plays.</value>
        public int Plays { get; set; }

        /// <summary>
        ///     Gets or sets the total woots of the world.
        /// </summary>
        /// <value>The total woots.</value>
        public int TotalWoots { get; set; }

        /// <summary>
        ///     Gets or sets the name of the world.
        /// </summary>
        /// <value>The name of the world.</value>
        public string WorldName { get; set; }

        /// <summary>
        ///     Gets the block x.
        /// </summary>
        /// <value>The block x.</value>
        public int SpawnBlockX
        {
            get { return WorldUtils.PosToBlock(this.SpawnX); }
        }

        /// <summary>
        ///     Gets the block y.
        /// </summary>
        /// <value>The block y.</value>
        public int SpawnBlockY
        {
            get { return WorldUtils.PosToBlock(this.SpawnY); }
        }
    }
}