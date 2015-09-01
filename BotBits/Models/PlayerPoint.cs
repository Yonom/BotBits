using System;

namespace BotBits
{
    public struct PlayerPoint : IEquatable<PlayerPoint>
    {
        public PlayerPoint(Player player, int x, int y)
            : this()
        {
            this.Player = player;
            this.X = x;
            this.Y = y;
        }

        public bool Equals(PlayerPoint other)
        {
            return Equals(this.Player, other.Player) && this.X == other.X && this.Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is PlayerPoint && Equals((PlayerPoint) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (this.Player != null ? this.Player.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ this.X;
                hashCode = (hashCode*397) ^ this.Y;
                return hashCode;
            }
        }

        public static bool operator ==(PlayerPoint left, PlayerPoint right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PlayerPoint left, PlayerPoint right)
        {
            return !left.Equals(right);
        }

        public Player Player { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
