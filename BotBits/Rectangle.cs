using System;
using System.Diagnostics;

namespace BotBits
{
    [DebuggerDisplay("X = {X}, Y = {Y}, Width = {Width}, Height = {Height}")]
    public struct Rectangle : IEquatable<Rectangle>
    {
        public Rectangle(int x, int y, int width, int height)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public Rectangle(Point p1, Point p2)
            : this()
        {
            var topLeft = new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
            var bottomRight = new Point(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y));

            this.X = topLeft.X;
            this.Y = topLeft.Y;
            this.Width = bottomRight.X - topLeft.X;
            this.Height = bottomRight.Y - topLeft.Y; 
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Left
        {
            get { return X; }
        }

        public int Top
        {
            get { return Y; }
        }

        public int Right
        {
            get { return X + Width; }
        }

        public int Bottom
        {
            get { return Y + Height; }
        }

        public bool Contains(Point location)
        {
            return this.Left <= location.X &&
                   this.Top <= location.Y &&
                   this.Right >= location.X &&
                   this.Bottom >= location.Y;
        }

        public bool Equals(Rectangle other)
        {
            return this.X == other.X && this.Y == other.Y && this.Width == other.Width && this.Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Rectangle && this.Equals((Rectangle)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.X;
                hashCode = (hashCode * 397) ^ this.Y;
                hashCode = (hashCode * 397) ^ this.Width;
                hashCode = (hashCode * 397) ^ this.Height;
                return hashCode;
            }
        }

        public static bool operator ==(Rectangle left, Rectangle right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Rectangle left, Rectangle right)
        {
            return !left.Equals(right);
        }
    }
}