using System;
using System.Runtime.CompilerServices;

namespace BotBits
{
    public static class BlocksAreaEnumerableExtensions
    {
        public static BlocksAreaEnumerable In(this IBlockAreaEnumerable blockArea, Rectangle area)
        {
            return new BlocksAreaEnumerable(blockArea.Blocks,
                Rectangle.Intersect(area.Offset(blockArea.Area.X, blockArea.Area.Y), blockArea.Area));
        }

        public static BlocksAreaEnumerable In(this IBlockAreaEnumerable blockArea, Point p1, Point p2)
        {
            return blockArea.In(new Rectangle(p1, p2));
        }

        public static BlocksAreaEnumerable In(this IBlockAreaEnumerable blockArea, int x, int y, int width, int height)
        {
            return blockArea.In(new Rectangle(x, y, width, height));
        }

        public static BlocksItem At(this IBlockAreaEnumerable blockArea, int x, int y)
        {
            return new BlocksItem(blockArea.Blocks, blockArea.Area.X + x, blockArea.Area.Y + y);
        }

        public static BlocksItem At(this IBlockAreaEnumerable blockArea, Point point)
        {
            return blockArea.At(point.X, point.Y);
        }

        public static World CreateCopy(this IBlockAreaEnumerable blockArea)
        {
            var area = blockArea.Area;
            var world = new World(area.Width, area.Height);
            for (var x = area.Left; x <= area.Right; x++)
                for (var y = area.Top; y <= area.Bottom; y++)
                {
                    world.Foreground[x - area.Left, y - area.Top] = blockArea.Blocks.Foreground[x, y].Block;
                    world.Background[x - area.Left, y - area.Top] = blockArea.Blocks.Background[x, y].Block;
                }
            return world;
        }

        public static IReadOnlyWorldAreaEnumerable<ForegroundBlock, BackgroundBlock> GetProxyWorldAreaEnumerable(this IBlockAreaEnumerable blockArea)
        {
            return blockArea.Blocks.GetProxyWorld().In(blockArea.Area);
        }

        public static void UploadWorld(this IBlockAreaEnumerable blockArea, IReadOnlyWorld<ForegroundBlock, BackgroundBlock> world)
        {
            var area = blockArea.Area;
            if (world.Width > area.Width || world.Height > area.Height) throw new ArgumentException("The world is too big for this area.", nameof(world));

            for (var y = area.Top; y < area.Top + world.Height; y++)
                for (var x = area.Left; x < area.Left + world.Width; x++)
                {
                    blockArea.Blocks.Place(x, y, world.Foreground[x - area.Left, y - area.Top]);
                    blockArea.Blocks.Place(x, y, world.Background[x - area.Left, y - area.Top]);
                }
        }
    }
}