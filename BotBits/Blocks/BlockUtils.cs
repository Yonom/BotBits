using System;
using System.Collections.Generic;
using System.Linq;
using BotBits.Events;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    public static class BlockUtils
    {
        private const uint InitOffset = 24;

        internal static BlockDataWorld GetWorld(Message m, int width, int height, uint offset = InitOffset)
        {
            var world = new BlockDataWorld(width, height);
            uint pointer = GetStart(m, offset);

            string strValue2;
            while ((strValue2 = m[pointer] as string) == null || strValue2 != "we")
            {
                var block = m.GetInteger(pointer++);
                var l = (Layer)m.GetInteger(pointer++);
                byte[] byteArrayX = m.GetByteArray(pointer++);
                byte[] byteArrayY = m.GetByteArray(pointer++);

                switch (l)
                {
                    case Layer.Background:
                        var bgWorldBlock = new BackgroundBlock((Background.Id)block);
                        foreach (Point pos in GetPos(byteArrayX, byteArrayY))
                            world.Background[pos.X, pos.Y] = new BlockData<BackgroundBlock>(bgWorldBlock);
                        break;

                    case Layer.Foreground:
                        ForegroundBlock foregroundBlock;
                        BlockArgsType blockArgsType = WorldUtils.GetBlockArgsType(WorldUtils.GetForegroundType(id: (Foreground.Id)block));

                        switch (blockArgsType)
                        {
                            case BlockArgsType.None:
                                foregroundBlock = new ForegroundBlock((Foreground.Id)block);
                                break;

                            case BlockArgsType.Number:
                                uint i = m.GetUInt(pointer++);
                                foregroundBlock = new ForegroundBlock((Foreground.Id)block, i);
                                break;

                            case BlockArgsType.String:
                                string str = m.GetString(pointer++);
                                foregroundBlock = new ForegroundBlock((Foreground.Id)block, str);
                                break;

                            case BlockArgsType.Portal:
                                var portalRotation = (PortalRotation)m.GetUInt(pointer++);
                                uint portalId = m.GetUInt(pointer++);
                                uint portalTarget = m.GetUInt(pointer++);
                                foregroundBlock = new ForegroundBlock((Foreground.Id)block, portalId, portalTarget, portalRotation);
                                break;

                            case BlockArgsType.Label:
                                string text = m.GetString(pointer++);
                                string textcolor = m.GetString(pointer++);
                                foregroundBlock = new ForegroundBlock((Foreground.Id)block, text, textcolor);
                                break;

                            default:
                                throw new NotSupportedException("Invalid block.");
                        }

                        var fg = new BlockData<ForegroundBlock>(foregroundBlock);
                        foreach (Point pos in GetPos(byteArrayX, byteArrayY))
                            world.Foreground[pos.X, pos.Y] = fg;
                        break;
                }
            }

            return world;
        }

        private static uint GetStart(Message m, uint offset)
        {
            uint start = 0;
            for (uint i = offset; i <= m.Count - 1; i++)
            {
                string strValue;
                if ((strValue = m[i] as string) != null && strValue == "ws")
                {
                    start = i + 1;
                    break;
                }
            }
            return start;
        }

        private static IEnumerable<Point> GetPos(byte[] byteArrayX, byte[] byteArrayY)
        {
            for (int i = 0; i <= byteArrayX.Length - 1; i += 2)
            {
                int x = byteArrayX[i] * 256 + byteArrayX[i + 1];
                int y = byteArrayY[i] * 256 + byteArrayY[i + 1];

                yield return new Point(x, y);
            }
        }

        internal static BlockDataWorld GetClearedWorld(int width, int height, Foreground.Id borderBlock)
        {
            var world = new BlockDataWorld(width, height);
            WorldUtils.DrawBorder(world, new BlockData<ForegroundBlock>(new ForegroundBlock(borderBlock)));
            return world;
        }
    }
}