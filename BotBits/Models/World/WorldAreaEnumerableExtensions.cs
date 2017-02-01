using System;
using System.ComponentModel;

namespace BotBits
{
    public static class WorldAreaEnumerableExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static WorldAreaEnumerable<TForeground, TBackground> AsWorldAreaEnumerable<TForeground, TBackground>(
            this IWorld<TForeground, TBackground> world)
            where TForeground : struct
            where TBackground : struct
        {
            return new WorldAreaEnumerable<TForeground, TBackground>(world, new Rectangle(0, 0, world.Width, world.Height));
        }
        
        public static WorldAreaEnumerable<TForeground, TBackground> In<TForeground, TBackground>(
            this IWorldAreaEnumerable<TForeground, TBackground> blockArea, Rectangle area)
            where TForeground : struct
            where TBackground : struct
        {
            return new WorldAreaEnumerable<TForeground, TBackground>(blockArea.World,
                Rectangle.Intersect(area, blockArea.Area));
        }

        public static WorldAreaEnumerable<TForeground, TBackground> In<TForeground, TBackground>(
            this IWorldAreaEnumerable<TForeground, TBackground> blockArea, Point p1, Point p2)
            where TForeground : struct
            where TBackground : struct
        {
            return blockArea.In(new Rectangle(p1, p2));
        }

        public static WorldAreaEnumerable<TForeground, TBackground> In<TForeground, TBackground>(
            this IWorldAreaEnumerable<TForeground, TBackground> blockArea, int x, int y, int width, int height)
            where TForeground : struct
            where TBackground : struct
        {
            return blockArea.In(new Rectangle(x, y, width, height));
        }

        public static WorldItem<TForeground, TBackground> At<TForeground, TBackground>(
            this IWorldAreaEnumerable<TForeground, TBackground> blockArea, int x, int y)
            where TForeground : struct
            where TBackground : struct
        {
            return new WorldItem<TForeground, TBackground>(blockArea.World, blockArea.Area.X + x, blockArea.Area.Y + y);
        }

        public static WorldItem<TForeground, TBackground> At<TForeground, TBackground>(
            this IWorldAreaEnumerable<TForeground, TBackground> blockArea, Point point)
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
        public static World CreateCopy(this IWorldAreaEnumerable<ForegroundBlock, BackgroundBlock> worldArea)
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

        public static void SetWorld<TForeground, TBackground>(
            this IWorldAreaEnumerable<TForeground, TBackground> worldArea,
            IWorldAreaEnumerable<TForeground, TBackground> worldArea2)
            where TForeground : struct
            where TBackground : struct
        {
            var area = worldArea.Area;
            if (worldArea2.Area.Width > area.Width || worldArea2.Area.Height > area.Height) throw new ArgumentException("The world is too big for this area.", nameof(worldArea2));

            for (var y = area.Top; y < area.Top + worldArea2.Area.Height; y++)
                for (var x = area.Left; x < area.Left + worldArea2.Area.Width; x++)
                {
                    worldArea.World.Foreground[x, y] = worldArea2.World.Foreground[x - area.Left, y - area.Top];
                    worldArea.World.Background[x, y] = worldArea2.World.Background[x - area.Left, y - area.Top];
                }
        }
    }
}