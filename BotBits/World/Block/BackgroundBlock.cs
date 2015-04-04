using System;
using System.Diagnostics;

namespace BotBits
{
    [DebuggerDisplay("Id = {Id}")]
    public struct BackgroundBlock : IEquatable<BackgroundBlock>
    {
        public bool Equals(BackgroundBlock other)
        {
            return this._id == other._id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is BackgroundBlock && Equals((BackgroundBlock)obj);
        }

        public override int GetHashCode()
        {
            return (int)this._id;
        }

        public static bool operator ==(BackgroundBlock left, BackgroundBlock right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BackgroundBlock left, BackgroundBlock right)
        {
            return !left.Equals(right);
        }

        private readonly Background.Id _id;

        public BackgroundBlock(Background.Id id)
        {
            this._id = id;
        }

        public Background.Id Id
        {
            get { return this._id; }
        }
    }
}