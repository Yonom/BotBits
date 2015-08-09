using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using JetBrains.Annotations;

namespace BotBits
{
    [DebuggerDisplay("X = {X}, Y = {Y}, Width = {Width}, Height = {Height}")]
    public struct Rectangle : IEquatable<Rectangle>
    {
        public static readonly Rectangle Empty = new Rectangle();

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

        [Browsable(false)]
        public int Left
        {
            get { return this.X; }
        }

        [Browsable(false)]
        public int Top
        {
            get { return this.Y; }
        }

        [Browsable(false)]
        public int Right
        {
            get { return this.X + this.Width - 1; }
        }

        [Browsable(false)]
        public int Bottom
        {
            get { return this.Y + this.Height - 1; }
        }

        public bool Equals(Rectangle other)
        {
            return this.X == other.X && this.Y == other.Y && this.Width == other.Width && this.Height == other.Height;
        }

        [Pure]
        public bool Contains(Point location)
        {
            return this.Left <= location.X &&
                   this.Top <= location.Y &&
                   this.Right >= location.X &&
                   this.Bottom >= location.Y;
        }

        [Pure]
        public bool Contains(Rectangle rect)
        {
            return (this.X <= rect.X) &&
                   ((rect.X + rect.Width) <= (this.X + this.Width)) &&
                   (this.Y <= rect.Y) &&
                   ((rect.Y + rect.Height) <= (this.Y + this.Height));
        }

        public void Offset(int x, int y)
        {
            this.X += x;
            this.Y += y;
        }

        public void Offset(Point pos)
        {
            this.Offset(pos.X, pos.Y);
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
                var hashCode = this.X;
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

        public override string ToString()
        {
            return "{X=" + this.X.ToString(CultureInfo.CurrentCulture) + ",Y=" +
                   this.Y.ToString(CultureInfo.CurrentCulture) +
                   ",Width=" + this.Width.ToString(CultureInfo.CurrentCulture) +
                   ",Height=" + this.Height.ToString(CultureInfo.CurrentCulture) + "}";
        }

        [Pure]
        public static Rectangle Union(Rectangle a, Rectangle b)
        {
            var x1 = Math.Min(a.X, b.X);
            var x2 = Math.Max(a.X + a.Width, b.X + b.Width);
            var y1 = Math.Min(a.Y, b.Y);
            var y2 = Math.Max(a.Y + a.Height, b.Y + b.Height);

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        [Pure]
        public bool IntersectsWith(Rectangle rect)
        {
            return (rect.X < this.X + this.Width) &&
                   (this.X < (rect.X + rect.Width)) &&
                   (rect.Y < this.Y + this.Height) &&
                   (this.Y < rect.Y + rect.Height);
        }

        public static Rectangle Intersect(Rectangle a, Rectangle b)
        {
            var x1 = Math.Max(a.X, b.X);
            var x2 = Math.Min(a.X + a.Width, b.X + b.Width);
            var y1 = Math.Max(a.Y, b.Y);
            var y2 = Math.Min(a.Y + a.Height, b.Y + b.Height);

            if (x2 >= x1
                && y2 >= y1)
            {
                return new Rectangle(x1, y1, x2 - x1, y2 - y1);
            }
            return Empty;
        }

        public void Intersect(Rectangle rect)
        {
            var result = Intersect(rect, this);

            this.X = result.X;
            this.Y = result.Y;
            this.Width = result.Width;
            this.Height = result.Height;
        }

        public static Rectangle Inflate(Rectangle rect, int x, int y)
        {
            var r = rect;
            r.Inflate(x, y);
            return r;
        }

        public void Inflate(int width, int height)
        {
            this.X -= width;
            this.Y -= height;
            this.Width += 2 * width;
            this.Height += 2 * height;
        }
    }
}