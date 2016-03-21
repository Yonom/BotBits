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
                        foreach (var pos in data.Locations) world.Background[pos.X, pos.Y] = new BlockData<BackgroundBlock>(bgWorldBlock);
                        break;

                    case Layer.Foreground:
                        var blockArgsType = WorldUtils.GetBlockArgsType(WorldUtils.GetForegroundType((Foreground.Id)block));

                        ForegroundBlock foregroundBlock;
                        switch (blockArgsType)
                        {
                            case BlockArgsType.None:
                            {
                                foregroundBlock = new ForegroundBlock((Foreground.Id)block);
                                break;
                            }

                            case BlockArgsType.Number:
                            {
                                var i = (uint)data.Args[0];
                                foregroundBlock = new ForegroundBlock((Foreground.Id)block, i);
                                break;
                            }

                            case BlockArgsType.SignedNumber:
                            {
                                var si = (int)data.Args[0];
                                foregroundBlock = new ForegroundBlock((Foreground.Id)block, si);
                                break;
                            }

                            case BlockArgsType.String:
                            {
                                var str = (string)data.Args[0];
                                foregroundBlock = new ForegroundBlock((Foreground.Id)block, str);
                                break;
                            }

                            case BlockArgsType.Portal:
                            {
                                var portalRotation = (Morph.Id)(uint)data.Args[0];
                                var portalId = (uint)data.Args[1];
                                var portalTarget = (uint)data.Args[2];
                                foregroundBlock = new ForegroundBlock((Foreground.Id)block, portalId, portalTarget,
                                    portalRotation);
                                break;
                            }

                            case BlockArgsType.Label:
                            {
                                var text = (string)data.Args[0];
                                var textcolor = (string)data.Args[1];
                                foregroundBlock = new ForegroundBlock((Foreground.Id)block, text, textcolor);
                                break;
                            }

                            case BlockArgsType.Sign:
                            {
                                var text = (string)data.Args[0];
                                var color = (Morph.Id)(uint)data.Args[1];
                                foregroundBlock = new ForegroundBlock((Foreground.Id)block, text, color);
                                break;
                            }

                            default:
                                throw new NotSupportedException("Invalid block.");
                        }

                        var fg = new BlockData<ForegroundBlock>(foregroundBlock);
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