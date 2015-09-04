using System;

namespace BotBits
{
    public static class WorldAreaEnumerableExtensions
    {
        public static WorldAreaEnumerable<TForeground, TBackground> In<TForeground, TBackground>(this IWorldAreaEnumerable<TForeground, TBackground> blockArea, Rectangle area)
            where TForeground : struct
            where TBackground : struct
        {
            return new WorldAreaEnumerable<TForeground, TBackground>(blockArea.World,
                Rectangle.Intersect(area, blockArea.Area));
        }

        public static WorldAreaEnumerable<TForeground, TBackground> In<TForeground, TBackground>(this IWorldAreaEnumerable<TForeground, TBackground> blockArea, Point p1, Point p2)
            where TForeground : struct
            where TBackground : struct
        {
            return blockArea.In(new Rectangle(p1, p2));
        }

        public static WorldAreaEnumerable<TForeground, TBackground> In<TForeground, TBackground>(this IWorldAreaEnumerable<TForeground, TBackground> blockArea, int x, int y, int width, int height)
            where TForeground : struct
            where TBackground : struct
        {
            return blockArea.In(new Rectangle(x, y, width, height));
        }

        /// <summary>
        /// Creates a copy of the given world.
        /// </summary>
        /// <typeparam name="TForeground">The type of the foreground.</typeparam>
        /// <typeparam name="TBackground">The type of the background.</typeparam>
        /// <param name="worldArea">The block area.</param>
        /// <returns></returns>
        public static World CreateCopy(this IWorldAreaEnumerable<ForegroundBlock, BackgroundBlock> worldArea) 
        {
            var area = worldArea.Area;
            var world = new World(area.Width, area.Height);
            for (var x = area.Left; x <= area.Right; x++)
                for (var y = area.Top; y <= area.Bottom; y++)
                {
                    world.Foreground[x - area.Left, y - area.Top] = worldArea.World.Foreground[x, y];
                    world.Background[x - area.Left, y - area.Top] = worldArea.World.Background[x, y];
                }
            return world;
        }

        public static void SetWorld<TForeground, TBackground>(this IWorldAreaEnumerable<TForeground, TBackground> worldArea, IWorldAreaEnumerable<TForeground, TBackground> worldArea2) 
            where TForeground : struct 
            where TBackground : struct
        {
            var area = worldArea.Area;
            if (worldArea2.Area.Width > area.Width || worldArea2.Area.Height > area.Height)
                throw new ArgumentException("The world is too big for this area.", "worldArea2");

            for (var y = area.Top; y < area.Top + worldArea2.Area.Height; y++)
                for (var x = area.Left; x < area.Left + worldArea2.Area.Width; x++)
                {
                    worldArea.World.Foreground[x, y] = worldArea2.World.Foreground[x - area.Left, y - area.Top];
                    worldArea.World.Background[x, y] = worldArea2.World.Background[x - area.Left, y - area.Top];
                }
        }
    }
}
