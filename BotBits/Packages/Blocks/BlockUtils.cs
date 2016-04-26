using System;
using PlayerIOClient;
using Yonom.EE;

namespace BotBits
{
    internal static class BlockUtils
    {
        internal static BlockDataWorld GetWorld(Message m, int width, int height)
        {
            var world = new BlockDataWorld(width, height);
            var datas = InitParse.Parse(m);

            foreach (var data in datas)
            {
                var block = data.Type;
                var l = (Layer)data.Layer;

                switch (l)
                {
                    case Layer.Background:
                        var bgWorldBlock = new BackgroundBlock((Background.Id)block);
                        var bg = new BlockData<BackgroundBlock>(bgWorldBlock);
                        foreach (var pos in data.Locations) world.Background[pos.X, pos.Y] = bg;
                        break;

                    case Layer.Foreground:
                        var fgWorldBlock = WorldUtils.GetForegroundFromArgs((Foreground.Id)block, data.Args);
                        var fg = new BlockData<ForegroundBlock>(fgWorldBlock);
                        foreach (var pos in data.Locations) world.Foreground[pos.X, pos.Y] = fg;
                        break;
                }
            }

            return world;
        }

        internal static BlockDataWorld GetClearedWorld(int width, int height, Foreground.Id borderBlock)
        {
            var world = new BlockDataWorld(width, height);
            WorldUtils.DrawBorder(world, new BlockData<ForegroundBlock>(new ForegroundBlock(borderBlock)));
            return world;
        }
    }
}