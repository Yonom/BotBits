using System;

namespace BotBits
{
    public static class BlockAreaEnumerableExtensions
    {
        public static BlockAreaEnumerable In(this IBlockAreaEnumerable blockArea, Rectangle area)
        {
            return new BlockAreaEnumerable(blockArea.Blocks,
                Rectangle.Intersect(area, blockArea.Area));
        }

        public static BlockAreaEnumerable In(this IBlockAreaEnumerable blockArea, Point p1, Point p2)
        {
            return blockArea.In(new Rectangle(p1, p2));
        }

        public static BlockAreaEnumerable In(this IBlockAreaEnumerable blockArea, int x, int y, int width, int height)
        {
            return blockArea.In(new Rectangle(x, y, width, height));
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

        public static void UploadWorld(this IBlockAreaEnumerable blockArea, IWorld world)
        {
            var area = blockArea.Area;
            if (world.Width > area.Width || world.Height > area.Height)
                throw new ArgumentException("The world is too big for this area.", "world");

            for (var y = area.Top; y < area.Top + world.Height; y++)
                for (var x = area.Left; x < area.Left + world.Width; x++)
                {
                    blockArea.Blocks.Place(x, y, world.Foreground[x - area.Left, y - area.Top]);
                    blockArea.Blocks.Place(x, y, world.Background[x - area.Left, y - area.Top]);
                }
        }
    }
}