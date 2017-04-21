using System;
using System.Diagnostics;

namespace BotBits
{
    // ReSharper disable NonReadonlyMemberInGetHashCode
    [DebuggerDisplay("X = {Width}, Y = {Height}")]
    public struct Size : IEquatable<Size>
    {
        public Size(int width, int height)
            : this()
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public bool Equals(Size other)
        {
            return this.Width == other.Width && this.Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Size && this.Equals((Size)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Width * 397) ^ this.Height;
            }
        }

        public static bool operator ==(Size left, Size right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Size left, Size right)
        {
            return !left.Equals(right);
        }
    }
}