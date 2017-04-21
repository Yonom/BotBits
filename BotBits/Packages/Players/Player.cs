using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace BotBits
{
    [DebuggerDisplay("Username = {Username}, Smiley = {Smiley}")]
    public sealed class Player : MetadataCollection, IEquatable<Player>
    {
        public static readonly Player Nobody = new Player(null, -1) { Username = String.Empty };
        private readonly HashSet<Point> _blueCoins = new HashSet<Point>();

        [CanBeNull]
        private readonly BotBitsClient _botBits;

        private readonly Dictionary<Effect, ActiveEffect> _effects = new Dictionary<Effect, ActiveEffect>();
        private readonly HashSet<Point> _goldCoins = new HashSet<Point>();
        private readonly HashSet<int> _switches = new HashSet<int>();

        internal Player([CanBeNull] BotBitsClient botBits, int userId)
        {
            this._botBits = botBits;
            this.UserId = userId;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public BotBitsClient BotBits
        {
            get
            {
                if (this == Nobody) throw new NotSupportedException("Cannot access BotBits on Player.Nobody.");
                return this._botBits;
            }
        }

        /// <summary>
        ///     Gets the player's username.
        /// </summary>
        /// <value>
        ///     The player's username.
        /// </value>
        public string Username { get; internal set; }

        /// <summary>
        ///     Gets the player's user identifier.
        /// </summary>
        /// <value>
        ///     The player's user identifier.
        /// </value>
        public int UserId { get; }

        /// <summary>
        ///     Gets a value indicating whether this player has god mode enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this this player has god mode enabled; otherwise, <c>false</c>.
        /// </value>
        public bool GodMode { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player has admin mode enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player has admin mode enabled; otherwise, <c>false</c>.
        /// </value>
        public bool AdminMode { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player has moderator mode enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player has moderator mode enabled; otherwise, <c>false</c>.
        /// </value>
        public bool ModMode { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player is the bot user's friend.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player is the bot user's friend; otherwise, <c>false</c>.
        /// </value>
        public bool Friend { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player is a Gold member.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player is a Builder's Club member; otherwise, <c>false</c>.
        /// </value>
        public bool GoldMember { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player is connected.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        public bool Connected { get; internal set; }

        /// <summary>
        ///     Gets or sets the user identifier unique to this user's account.
        /// </summary>
        /// <value>
        ///     The user identifier.
        /// </value>
        public string ConnectUserId { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this player has chat access.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player has chat access; otherwise, <c>false</c>.
        /// </value>
        public bool HasChat { get; internal set; }

        /// <summary>
        ///     Gets the player's smiley.
        /// </summary>
        /// <value>
        ///     The player's smiley.
        /// </value>
        public Smiley Smiley { get; internal set; }

        /// <summary>
        ///     Gets the aura color that apperars around this user when they go in god mode.
        /// </summary>
        /// <value>
        ///     The aura color.
        /// </value>
        public AuraColor AuraColor { get; internal set; }

        /// <summary>
        ///     Gets the aura shape that apperars around this user when they go in god mode.
        /// </summary>
        /// <value>
        ///     The aura shape.
        /// </value>
        public AuraShape AuraShape { get; internal set; }

        /// <summary>
        ///     Gets the badge this player has selected.
        /// </summary>
        /// <value>
        ///     The badge.
        /// </value>
        public Badge Badge { get; internal set; }

        /// <summary>
        ///     Gets the player's number of coins.
        /// </summary>
        /// <value>
        ///     The player's number of coins.
        /// </value>
        public int GoldCoins { get; internal set; }

        /// <summary>
        ///     Gets the player's number of blue coins.
        /// </summary>
        /// <value>
        ///     The player's number of blue coins.
        /// </value>
        public int BlueCoins { get; internal set; }

        /// <summary>
        ///     Gets the x-coordinate of the player's current position.
        /// </summary>
        /// <value>
        ///     The x-coordinate of the player's current position.
        /// </value>
        public double X { get; internal set; }

        /// <summary>
        ///     Gets the y-coordinate of the player's current position.
        /// </summary>
        /// <value>
        ///     The y-coordinate of the player's current position.
        /// </value>
        public double Y { get; internal set; }

        /// <summary>
        ///     Gets the player's horizontal speed.
        /// </summary>
        /// <value>
        ///     The player's horizontal speed.
        /// </value>
        public double SpeedX { get; internal set; }

        /// <summary>
        ///     Gets the player's vertical speed.
        /// </summary>
        /// <value>
        ///     The player's vertical speed
        /// </value>
        public double SpeedY { get; internal set; }

        /// <summary>
        ///     Gets the player's horizontal speed modifier.
        /// </summary>
        /// <value>
        ///     The player's horizontal speed modifier.
        /// </value>
        public double ModifierX { get; internal set; }

        /// <summary>
        ///     Gets the player's vertical speed modifier.
        /// </summary>
        /// <value>
        ///     The player's vertical speed modifier.
        /// </value>
        public double ModifierY { get; internal set; }

        /// <summary>
        ///     Gets the player's horizontal speed direction.
        /// </summary>
        /// <value>
        ///     The player's horizontal speed direction.
        /// </value>
        public double Horizontal { get; internal set; }

        /// <summary>
        ///     Gets the player's vertical speed direction.
        /// </summary>
        /// <value>
        ///     The player's vertical speed direction.
        /// </value>
        public double Vertical { get; internal set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the player is pressing spacebar.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the player is pressing spacebar; otherwise, <c>false</c>.
        /// </value>
        public bool SpaceDown { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether has just pressed spacebar.
        /// </summary>
        /// <value>
        ///     <c>true</c> if space was just pressed; otherwise, <c>false</c>.
        /// </value>
        public bool SpaceJustDown { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player has a silver crown.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player has a silver crown; otherwise, <c>false</c>.
        /// </value>
        public bool HasSilverCrown { get; internal set; }

        /// <summary>
        ///     Gets the team this user is in.
        /// </summary>
        /// <value>
        ///     The team.
        /// </value>
        public Team Team { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player has a crown.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player has a crown; otherwise, <c>false</c>.
        /// </value>
        public bool HasCrown => this.BotBits != null && Players.Of(this.BotBits).CrownPlayer == this;

        /// <summary>
        ///     Gets the color of this user's name when he/she chats.
        /// </summary>
        /// <value>
        ///     The color of the chat.
        /// </value>
        public uint ChatColor { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player is a crew member.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the player is a crew member; otherwise, <c>false</c>.
        /// </value>
        public bool CrewMember { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player is flying using god mode, admin mode or moderator mode.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player is flying using god mode, admin mode or moderator mode; otherwise, <c>false</c>.
        /// </value>
        public bool Flying => this.GodMode || this.AdminMode || this.ModMode;

        /// <summary>
        ///     Gets a value indicating whether this player is a guest.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player is a guest; otherwise, <c>false</c>.
        /// </value>
        public bool Guest => IsGuest(this.Username);

        /// <summary>
        ///     Gets the player's chat name.
        /// </summary>
        /// <value>
        ///     The player's chat name.
        /// </value>
        [CanBeNull]
        public string ChatName => GetChatName(this.Username);

        /// <summary>
        ///     Gets a value indicating whether this <see cref="Player" /> is the room owner.
        /// </summary>
        /// <value>
        ///     <c>true</c> if owner; otherwise, <c>false</c>.
        /// </value>
        public bool Owner => this != Nobody && this.Username.Equals(Room.Of(this.BotBits).Owner, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        ///     Gets the x-coordinate of the block that the player is located on.
        /// </summary>
        /// <value>
        ///     The x-coordinate of the block that the player is located on.
        /// </value>
        public int BlockX => WorldUtils.PosToBlock(this.X);

        /// <summary>
        ///     Gets the y-coordinate of the block that the player is located on.
        /// </summary>
        /// <value>
        ///     The y-coordinate of the block that the player is located on.
        /// </value>
        public int BlockY => WorldUtils.PosToBlock(this.Y);

        public bool HasGodRights { get; internal set; }

        public bool HasEditRights { get; internal set; }

        public int Deaths { get; internal set; }

        public bool Muted { get; set; }

        public bool GoldBorder { get; set; }

        public bool CanToggleGod => this.HasGodRights || this.HasEditRights;

        public bool Equals(Player other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.UserId == other.UserId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Player && this.Equals((Player)obj);
        }

        public override int GetHashCode()
        {
            return this.UserId;
        }

        public static bool operator ==(Player left, Player right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Player left, Player right)
        {
            return !Equals(left, right);
        }

        [Pure]
        public bool HasPressedSwitch(int id)
        {
            lock (this._switches)
            {
                return this._switches.Contains(id);
            }
        }

        [Pure]
        public int[] GetSwitches()
        {
            lock (this._switches)
            {
                return this._switches.ToArray();
            }
        }

        internal void AddSwitch(int id)
        {
            lock (this._switches)
            {
                this._switches.Add(id);
            }
        }

        internal void RemoveSwitch(int id)
        {
            lock (this._switches)
            {
                this._switches.Remove(id);
            }
        }

        internal void ResetSwitches()
        {
            lock (this._switches)
            {
                this._switches.Clear();
            }
        }


        [Pure]
        public bool HasEffect(Effect effect)
        {
            lock (this._effects)
            {
                return this._effects.ContainsKey(effect);
            }
        }

        [Pure]
        public ActiveEffect[] GetEffects()
        {
            lock (this._effects)
            {
                return this._effects.Values.ToArray();
            }
        }

        internal void SetEffect(ActiveEffect effect)
        {
            lock (this._effects)
            {
                this._effects[effect.Effect] = effect;
            }
        }

        internal void RemoveEffect(Effect effect)
        {
            lock (this._effects)
            {
                this._effects.Remove(effect);
            }
        }

        [Pure]
        public bool HasGoldCoin(Point loc)
        {
            lock (this._goldCoins)
            {
                return this._goldCoins.Contains(loc);
            }
        }

        [Pure]
        public Point[] GetGoldCoins()
        {
            lock (this._goldCoins)
            {
                return this._goldCoins.ToArray();
            }
        }

        [Pure]
        public int GetGoldCoinsCount()
        {
            lock (this._goldCoins)
            {
                return this._goldCoins.Count;
            }
        }

        internal void AddGoldCoin(Point loc)
        {
            lock (this._goldCoins)
            {
                this._goldCoins.Add(loc);
            }
        }

        internal void RemoveGoldCoin(Point loc)
        {
            lock (this._goldCoins)
            {
                this._goldCoins.Remove(loc);
            }
        }

        public void ClearGoldCoins()
        {
            lock (this._goldCoins)
            {
                this._goldCoins.Clear();
            }
        }


        [Pure]
        public bool HasBlueCoin(Point loc)
        {
            lock (this._blueCoins)
            {
                return this._blueCoins.Contains(loc);
            }
        }

        [Pure]
        public Point[] GetBlueCoins()
        {
            lock (this._blueCoins)
            {
                return this._blueCoins.ToArray();
            }
        }

        [Pure]
        public int GetBlueCoinsCount()
        {
            lock (this._blueCoins)
            {
                return this._blueCoins.Count;
            }
        }

        internal void AddBlueCoin(Point loc)
        {
            lock (this._blueCoins)
            {
                this._blueCoins.Add(loc);
            }
        }

        internal void RemoveBlueCoin(Point loc)
        {
            lock (this._blueCoins)
            {
                this._blueCoins.Remove(loc);
            }
        }

        public void ClearBlueCoins()
        {
            lock (this._blueCoins)
            {
                this._blueCoins.Clear();
            }
        }

        public override void Set<T>(string id, T value)
        {
            if (this == Nobody) throw new NotSupportedException("Cannot set metadata on Player.Nobody.");

            base.Set(id, value);
        }

        /// <summary>
        ///     Determines whether the player with the specified username is a guest.
        /// </summary>
        /// <param name="username">The player's username.</param>
        /// <returns></returns>
        [Pure]
        public static bool IsGuest(string username)
        {
            // Official implementation in SWF, don't blame me
            return username.Contains("-");
        }

        /// <summary>
        ///     Gets the chat name of the specified player.
        /// </summary>
        /// <param name="username">The player's username.</param>
        /// <returns></returns>
        [Pure]
        public static string GetChatName(string username)
        {
            return username.ToUpperInvariant();
        }
    }
}