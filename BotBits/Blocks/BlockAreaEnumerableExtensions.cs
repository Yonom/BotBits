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
            var world = new World(blockArea.Area.Width, blockArea.Area.Height);
            for (var x = 0; x < blockArea.Area.Width; x++)
                for (var y = 0; y < blockArea.Area.Height; y++)
                {
                    world.Foreground[x, y] = blockArea.Blocks.Foreground[x, y].Block;
                    world.Background[x, y] = blockArea.Blocks.Background[x, y].Block;
                }
            return world;
        }

        public static void UploadWorld(this IBlockAreaEnumerable blockArea, World world)
        {
            if (world.Width > blockArea.Area.Width || world.Height > blockArea.Area.Height)
                throw new ArgumentException("The world is too big for this area.", "world");

            for (var y = 0; y < blockArea.Area.Height; y++)
                for (var x = 0; x < blockArea.Area.Width; x++)
                {
                    blockArea.Blocks.Place(x, y, world.Foreground[x, y]);
                    blockArea.Blocks.Place(x, y, world.Background[x, y]);
                }
        }
    }
}