using System;
using System.ComponentModel;

namespace BotBits
{
    public static class ReadOnlyWorldAreaEnumerableExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static ReadOnlyWorldAreaEnumerable<TForeground, TBackground> ToReadOnlyWorldAreaEnumerable<TForeground, TBackground>(
            this IWorldAreaEnumerable<TForeground, TBackground> worldArea)
            where TForeground : struct
            where TBackground : struct
        {
            return new ReadOnlyWorldAreaEnumerable<TForeground, TBackground>(worldArea.World, worldArea.Area);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static ReadOnlyWorldAreaEnumerable<TForeground, TBackground> AsReadOnlyWorldAreaEnumerable<TForeground, TBackground>(
            this IReadOnlyWorld<TForeground, TBackground> world)
            where TForeground : struct
            where TBackground : struct
        {
            return new ReadOnlyWorldAreaEnumerable<TForeground, TBackground>(world, new Rectangle(0, 0, world.Width, world.Height));
        }

        public static ReadOnlyWorldAreaEnumerable<TForeground, TBackground> In<TForeground, TBackground>(
            this IReadOnlyWorldAreaEnumerable<TForeground, TBackground> blockArea, Rectangle area)
            where TForeground : struct
            where TBackground : struct
        {
            return new ReadOnlyWorldAreaEnumerable<TForeground, TBackground>(blockArea.World,
                Rectangle.Intersect(area.Offset(blockArea.Area.X, blockArea.Area.Y), blockArea.Area));
        }

        public static ReadOnlyWorldAreaEnumerable<TForeground, TBackground> In<TForeground, TBackground>(
            this IReadOnlyWorldAreaEnumerable<TForeground, TBackground> blockArea, Point p1, Point p2)
            where TForeground : struct
            where TBackground : struct
        {
            return blockArea.In(new Rectangle(p1, p2));
        }

        public static ReadOnlyWorldAreaEnumerable<TForeground, TBackground> In<TForeground, TBackground>(
            this IReadOnlyWorldAreaEnumerable<TForeground, TBackground> blockArea, int x, int y, int width, int height)
            where TForeground : struct
            where TBackground : struct
        {
            return blockArea.In(new Rectangle(x, y, width, height));
        }

        public static ReadOnlyWorldItem<TForeground, TBackground> At<TForeground, TBackground>(
            this IReadOnlyWorldAreaEnumerable<TForeground, TBackground> blockArea, int x, int y)
            where TForeground : struct
            where TBackground : struct
        {
            return new ReadOnlyWorldItem<TForeground, TBackground>(blockArea.World, blockArea.Area.X + x, blockArea.Area.Y + y);
        }

        public static ReadOnlyWorldItem<TForeground, TBackground> At<TForeground, TBackground>(
            this IReadOnlyWorldAreaEnumerable<TForeground, TBackground> blockArea, Point point)
            where TForeground : struct
            where TBackground : struct
        {
            return blockArea.At(point.X, point.Y);
        }

        /// <summary>
        ///     Creates a copy of the given world.
        /// </summary>
        /// <param name="worldArea">The block area.</param>
        /// <returns></returns>
        public static World CreateCopy(this IReadOnlyWorldAreaEnumerable<ForegroundBlock, BackgroundBlock> worldArea)
        {
            var area = worldArea.Area;
            var world = new World(area.Width, area.Height);
            for (var y = area.Top; y <= area.Bottom; y++)
                for (var x = area.Left; x <= area.Right; x++)
                {
                    world.Foreground[x - area.Left, y - area.Top] = worldArea.World.Foreground[x, y];
                    world.Background[x - area.Left, y - area.Top] = worldArea.World.Background[x, y];
                }
            return world;
        }
    }
}