using System;
using System.Collections.Generic;
using System.Linq;
using BotBits.Events;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    public static class WorldUtils
    {
        public static WorldType GetLegacyWorldType(int width, int height)
        {
            if (width == 25 && height == 25) return WorldType.Small;
            if (width == 50 && height == 50) return WorldType.Medium;
            if (width == 100 && height == 100) return WorldType.Large;
            if (width == 200 && height == 200) return WorldType.Massive;
            if (width == 400 && height == 50) return WorldType.Wide;
            if (width == 400 && height == 200) return WorldType.Great;
            if (width == 100 && height == 400) return WorldType.Tall;
            if (width == 636 && height == 50) return WorldType.UltraWide;
            if (width == 150 && height == 25) return WorldType.Tutorial;
            if (width == 110 && height == 110) return WorldType.MoonLarge;
            if (width == 300 && height == 300) return WorldType.Huge;
            if (width == 250 && height == 150) return WorldType.Big;
            return WorldType.Unknown;
        }

        public static ForegroundBlock GetDatabaseBlock(DatabaseObject obj, Foreground.Id foreground)
        {
            var foregroundType = GetForegroundType(foreground);

            switch (foregroundType)
            {
                case ForegroundType.Normal:
                    return new ForegroundBlock(foreground);

                case ForegroundType.Note:
                    return new ForegroundBlock(foreground,
                        obj.GetUInt("id", 0));

                case ForegroundType.Goal:
                case ForegroundType.Toggle:
                case ForegroundType.Team:
                    return new ForegroundBlock(foreground,
                        obj.GetUInt("goal", 0));

                case ForegroundType.Morphable:
                    return new ForegroundBlock(foreground,
                        obj.GetUInt("rotation", 0));

                case ForegroundType.Portal:
                    return new ForegroundBlock(foreground,
                        obj.GetUInt("id", 0),
                        obj.GetUInt("target", 0),
                        (Morph.Id)obj.GetUInt("rotation", 0));

                case ForegroundType.WorldPortal:
                    return new ForegroundBlock(foreground,
                        obj.GetString("target"));

                case ForegroundType.Text:
                    return new ForegroundBlock(foreground,
                        obj.GetString("text", "No text found."));

                case ForegroundType.Label:
                    return new ForegroundBlock(foreground,
                        obj.GetString("text", "no text found"),
                        obj.GetString("text_color", "#FFFFFF"));

                default:
                    throw new NotSupportedException("Encountered an unsupported block!");
            }
        }

        public static void DrawBorder<TForeground, TBackground>
            (World<TForeground, TBackground> world, TForeground borderBlock)
            where TForeground : struct
            where TBackground : struct
        {
            int maxX = world.Width - 1;
            int maxY = world.Height - 1;
            for (int y = 0; y <= maxY; y++)
            {
                world.Foreground[0, y] = borderBlock;
                world.Foreground[maxX, y] = borderBlock;
            }
            for (int x = 0; x <= maxX; x++)
            {
                world.Foreground[x, 0] = borderBlock;
                world.Foreground[x, maxY] = borderBlock;
            }
        }

        public static ForegroundType GetForegroundType(Foreground.Id id)
        {
            return BlockServices.GetPackageInternal((int)id).ForegroundType;

            //switch (id)
            //{
            //    case Foreground.Switch.Purple:
            //    case Foreground.Door.Coin:
            //    case Foreground.Gate.Coin:
            //    case Foreground.Door.BlueCoin:
            //    case Foreground.Gate.BlueCoin:
            //    case Foreground.Door.Purple:
            //    case Foreground.Gate.Purple:
            //    case Foreground.Door.Death:
            //    case Foreground.Gate.Death:
            //    case Foreground.Door.Team:
            //    case Foreground.Gate.Team:
            //    case Foreground.Effect.Jump:
            //    case Foreground.Effect.Fly:
            //    case Foreground.Effect.Protection:
            //    case Foreground.Effect.Speed:
            //    case Foreground.Effect.Curse:
            //    case Foreground.Effect.Zombie:
            //    case Foreground.Effect.Team:
            //        return ForegroundType.Goal;

            //    case Foreground.Hazard.Spike:
            //    case Foreground.OneWay.Cyan:
            //    case Foreground.OneWay.Pink:
            //    case Foreground.OneWay.Red:
            //    case Foreground.OneWay.Yellow:
            //        return ForegroundType.Rotatable;

            //    case Foreground.SciFi2013.BlueStraight:
            //    case Foreground.SciFi2013.YellowStraight:
            //    case Foreground.SciFi2013.GreenStraight:
            //        return ForegroundType.SciFiStraight;

            //    case Foreground.SciFi2013.YellowSlope:
            //    case Foreground.SciFi2013.GreenSlope:
            //    case Foreground.SciFi2013.BlueSlope:
            //        return ForegroundType.SciFiSlope;

            //    case Foreground.Music.Piano:
            //        return ForegroundType.Piano;

            //    case Foreground.Music.Drum:
            //        return ForegroundType.Drum;

            //    case Foreground.Portal.Invisible:
            //    case Foreground.Portal.Normal:
            //        return ForegroundType.Portal;

            //    case Foreground.Sign.Block:
            //        return ForegroundType.Text;

            //    case Foreground.Admin.Text:
            //        return ForegroundType.Label;

            //    case Foreground.Portal.World:
            //        return ForegroundType.WorldPortal;

            //    default:
            //        return ForegroundType.Normal;
            //}
        }

        public static BlockArgsType GetBlockArgsType(ForegroundType type)
        {
            switch (type)
            {
                case ForegroundType.Normal:
                    return BlockArgsType.None;

                case ForegroundType.Goal:
                case ForegroundType.Morphable:
                case ForegroundType.Toggle:
                case ForegroundType.Team:
                case ForegroundType.Note:
                    return BlockArgsType.Number;

                case ForegroundType.Text:
                case ForegroundType.WorldPortal:
                    return BlockArgsType.String;

                case ForegroundType.Portal:
                    return BlockArgsType.Portal;

                case ForegroundType.Label:
                    return BlockArgsType.Label;

                default:
                    throw new ArgumentException("Invalid BlockType.", "type");
            }
        }

        public static int PosToBlock(int pos)
        {
            return pos + 8 >> 4;
        }

        public static bool IsAlreadyPlaced(PlaceSendMessage sent, Blocks world)
        {
            switch (sent.Layer)
            {
                case Layer.Foreground:
                    var fg = world.Foreground[sent.X, sent.Y];
                    return sent.Id == (int)fg.Block.Id &&
                           sent.Args.SequenceEqual(fg.Block.GetArgs());
                case Layer.Background:
                    var bg = world.Background[sent.X, sent.Y];
                    return sent.Id == (int)bg.Block.Id;
                default:
                    throw new NotSupportedException("Unknown layer.");
            }
        }

        public static bool AreSame(PlaceSendMessage sent, ForegroundPlaceEvent received)
        {
            return sent.Id == (int)received.New.Block.Id &&
                   sent.Args.SequenceEqual(received.New.Block.GetArgs());
        }

        public static bool AreSame(PlaceSendMessage sent, BackgroundPlaceEvent received)
        {
            return sent.Id == (int)received.New.Block.Id;
        }

        public static bool AreSame(PlaceSendMessage b1, PlaceSendMessage b2)
        {
            return b1.Id == b2.Id && b1.Args.SequenceEqual(b2.Args);
        }

        public static bool IsPlaceable<TForeground, TBackground>
            (PlaceSendMessage p, IWorld<TForeground, TBackground> world, bool respectBorder)
            where TForeground : struct
            where TBackground : struct
        {
            if (p.X < 0 || p.Y < 0 || p.X >= world.Width || p.Y >= world.Height) return false; // If out of range

            if (!respectBorder) return true;
            if (p.X == 0 || p.Y == 0 || p.X == world.Width - 1 || p.Y == world.Height - 1) // If on border
            {
                if (p.Layer == Layer.Background)
                    return false;

                return IsBorderPlaceable((Foreground.Id)p.Id);
            }

            return true;
        }

        private static bool IsBorderPlaceable(Foreground.Id id)
        {
            if (id == Foreground.Special.FullyBlack)
                return true;

            var block = BlockServices.GetGroup((int)id);
            return block == typeof(Foreground.Basic) ||
                   block == typeof(Foreground.Beta) ||
                   block == typeof(Foreground.Brick);
        }
    }
}