using System;
using System.Collections.Generic;
using PlayerIOClient;

namespace BotBits
{
    public static class InitParse
    {
        public static DataChunk[] Parse(Message m)
        {
            if (m == null) throw new ArgumentNullException("m");
            if (m.Type != "init" && m.Type != "reset") throw new ArgumentException("Invalid message type.", "m");

            // Get world data
            var p = 0u;
            var data = new Stack<object>();
            while (m[p] as string != "ws") { ++p; }
            while (m[p] as string != "we") { data.Push(m[++p]); }

            // Parse world data
            var chunks = new List<DataChunk>();
            while (data.Count > 0)
            {
                var args = new Stack<object>();
                while (!(data.Peek() is byte[]))
                    args.Push(data.Pop());

                var ys = (byte[])data.Pop();
                var xs = (byte[])data.Pop();
                var layer = (int)data.Pop();
                var type = (uint)data.Pop();

                chunks.Add(new DataChunk(layer, type, xs, ys, args.ToArray()));
            }

            return chunks.ToArray();
        }
    }

    public class DataChunk
    {
        public int Layer { get; set; }
        public uint Type { get; set; }
        public Point[] Locations { get; set; }
        public object[] Args { get; set; }

        public DataChunk(int layer, uint type, byte[] xs, byte[] ys, object[] args)
        {
            this.Layer = layer;
            this.Type = type;
            this.Args = args;
            this.Locations = GetLocations(xs, ys);
        }

        private static Point[] GetLocations(byte[] xs, byte[] ys)
        {
            var points = new List<Point>();
            for (var i = 0; i < xs.Length; i += 2)
                points.Add(new Point(
                    (xs[i] << 8) | xs[i + 1],
                    (ys[i] << 8) | ys[i + 1]));
            return points.ToArray();
        }
    }
}