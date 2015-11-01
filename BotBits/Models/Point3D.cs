using System;
using System.Diagnostics;

namespace BotBits
{
    [DebuggerDisplay("Layer = {Layer}, X = {X}, Y = {Y}")]
    public struct Point3D : IEquatable<Point3D>
    {
        public Point3D(Layer layer, int x, int y)
            : this()
        {
            this.Layer = layer;
            this.X = x;
            this.Y = y;
        }

        public Layer Layer { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format("Layer = {0}, X = {1}, Y = {2}", this.Layer, this.X, this.Y);
        }

        public bool Equals(Point3D other)
        {
            return this.Layer == other.Layer && this.X == other.X && this.Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Point3D && this.Equals((Point3D) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) this.Layer;
                hashCode = (hashCode*397) ^ this.X;
                hashCode = (hashCode*397) ^ this.Y;
                return hashCode;
            }
        }

        public static bool operator ==(Point3D left, Point3D right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point3D left, Point3D right)
        {
            return !left.Equals(right);
        }
    }
}