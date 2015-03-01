using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace BotBits
{
    [DebuggerDisplay("Username = {Username}, Smiley = {Smiley}")]
    public sealed class Player : MetadataCollection, IEquatable<Player>
    {
        public static readonly Player Nobody = new Player(null, -1);

        [CanBeNull]
        private readonly Players _players;
        private readonly HashSet<Potion> _potions = new HashSet<Potion>();

        internal Player([CanBeNull] Players players, int userId)
        {
            this._players = players;
            this.UserId = userId;
        }
        
        /// <summary>
        ///     Gets the player's username.
        /// </summary>
        /// <value>
        ///     The player's username.
        /// </value>
        [CanBeNull]
        public string Username { get; internal set; }

        /// <summary>
        ///     Gets the player's user identifier.
        /// </summary>
        /// <value>
        ///     The player's user identifier.
        /// </value>
        public int UserId { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether this player has god mode enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this this player has god mode enabled; otherwise, <c>false</c>.
        /// </value>
        public bool GodMode { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player has guardian mode enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player has guardian mode enabled; otherwise, <c>false</c>.
        /// </value>
        public bool GuardianMode { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player has moderator mode enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player has moderator mode enabled; otherwise, <c>false</c>.
        /// </value>
        public bool ModMode { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player is dead.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player is dead; otherwise, <c>false</c>.
        /// </value>
        public bool Dead { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player is the bot user's friend.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player is the bot user's friend; otherwise, <c>false</c>.
        /// </value>
        public bool Friend { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player is a Builder's Club member.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player is a Builder's Club member; otherwise, <c>false</c>.
        /// </value>
        public bool ClubMember { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player is connected.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        public bool Connected { get; internal set; }

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
        ///     Gets the x-coordinate of the player's spawn.
        /// </summary>
        /// <value>
        ///     The x-coordinate of the player's spawn.
        /// </value>
        public int SpawnX { get; internal set; }

        /// <summary>
        ///     Gets the y-coordinate of the player's spawn.
        /// </summary>
        /// <value>
        ///     The y-coordinate of the player's spawn.
        /// </value>
        public int SpawnY { get; internal set; }

        /// <summary>
        ///     Gets the x-coordinate of the player's current position.
        /// </summary>
        /// <value>
        ///     The x-coordinate of the player's current position.
        /// </value>
        public int X { get; internal set; }

        /// <summary>
        ///     Gets the y-coordinate of the player's current position.
        /// </summary>
        /// <value>
        ///     The y-coordinate of the player's current position.
        /// </value>
        public int Y { get; internal set; }

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
        ///     Gets a value indicating whether this player has a silver crown.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player has a silver crown; otherwise, <c>false</c>.
        /// </value>
        public bool HasSilverCrown { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player has wooted the level.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player has wooted the level; otherwise, <c>false</c>.
        /// </value>
        public bool HasWooted { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this player has a crown.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player has a crown; otherwise, <c>false</c>.
        /// </value>
        public bool HasCrown
        {
            get { return this._players != null && this._players.CrownPlayer == this; }
        }

        /// <summary>
        ///     Gets a value indicating whether this player is flying using god mode, guardian mode or moderator mode.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player is flying using god mode, guardian mode or moderator mode; otherwise, <c>false</c>.
        /// </value>
        public bool Flying
        {
            get { return this.GodMode || this.GuardianMode || this.ModMode; }
        }

        /// <summary>
        ///     Gets a value indicating whether this player is a guest.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this player is a guest; otherwise, <c>false</c>.
        /// </value>
        public bool IsGuest
        {
            get { return PlayerUtils.IsGuest(this.Username); }
        }

        /// <summary>
        ///     Gets the player's chat name.
        /// </summary>
        /// <value>
        ///     The player's chat name.
        /// </value>
        [CanBeNull]
        public string ChatName
        {
            get { return PlayerUtils.GetChatName(this.Username); }
        }

        /// <summary>
        ///     Gets the x-coordinate of the block that the player is located on.
        /// </summary>
        /// <value>
        ///     The x-coordinate of the block that the player is located on.
        /// </value>
        public int BlockX
        {
            get { return BlockUtils.PosToBlock(this.X); }
        }

        /// <summary>
        ///     Gets the y-coordinate of the block that the player is located on.
        /// </summary>
        /// <value>
        ///     The y-coordinate of the block that the player is located on.
        /// </value>
        public int BlockY
        {
            get { return BlockUtils.PosToBlock(this.Y); }
        }

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
        public bool HasPotion(Potion potion)
        {
            lock (this._potions)
            {
                return this._potions.Contains(potion);
            }
        }

        [Pure]
        public Potion[] GetPotions()
        {
            lock (this._potions)
            {
                return this._potions.ToArray();
            }
        }

        internal void AddPotion(Potion potion)
        {
            lock (this._potions)
            {
                this._potions.Add(potion);
            }
        }

        internal void RemovePotion(Potion potion)
        {
            lock (this._potions)
            {
                this._potions.Remove(potion);
            }
        }

        public override void Set<T>(string id, T value)
        {
            if (this == Nobody)
                throw new NotSupportedException("Cannot set metadata on Player.Nobody.");

            base.Set(id, value);
        }
    }
}