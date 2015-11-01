using System;
using System.Diagnostics;

namespace BotBits
{
    [DebuggerDisplay("Id = {Id}")]
    public struct BackgroundBlock : IEquatable<BackgroundBlock>
    {
        public bool Equals(BackgroundBlock other)
        {
            return this.Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is BackgroundBlock && this.Equals((BackgroundBlock) obj);
        }

        public override int GetHashCode()
        {
            return (int) this.Id;
        }

        public static bool operator ==(BackgroundBlock left, BackgroundBlock right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BackgroundBlock left, BackgroundBlock right)
        {
            return !left.Equals(right);
        }

        public BackgroundBlock(Background.Id id)
        {
            this.Id = id;
        }

        public Background.Id Id { get; }
    }
}