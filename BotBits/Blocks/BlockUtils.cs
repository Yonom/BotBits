using System;
using System.Linq;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public static class BlockUtils
    {
        public static int PosToBlock(int pos)
        {
            return pos + 8 >> 4;
        }

        public static bool IsAlreadyPlaced(PlaceSendMessage sent, IWorld world)
        {
            switch (sent.Layer)
            {
                case Layer.Foreground:
                    var fg = world.Foreground[sent.X, sent.Y];
                    return sent.Id == (int)fg.Id &&
                           sent.Args.SequenceEqual(fg.GetArgs());
                case Layer.Background:
                    var bg = world.Background[sent.X, sent.Y];
                    return sent.Id == (int)bg.Id;
                default:
                    throw new NotSupportedException("Unknown layer.");
            }
        }

        public static bool AreSame(PlaceSendMessage sent, ForegroundPlaceEvent received)
        {
            return sent.Id == (int)received.NewBlock.Id &&
                sent.Args.SequenceEqual(received.NewBlock.GetArgs());
        }

        public static bool AreSame(PlaceSendMessage sent, BackgroundPlaceEvent received)
        {
            return sent.Id == (int)received.NewBlock.Id;
        }

        public static bool AreSame(PlaceSendMessage b1, PlaceSendMessage b2)
        {
            return b1.Id == b2.Id && b1.Args.SequenceEqual(b2.Args);
        }

        public static bool IsPlaceable(PlaceSendMessage p, IWorld world)
        {
            if (p.X < 0 || p.Y < 0 || p.X >= world.Width || p.Y >= world.Height) return false; // If out of range
            if (p.X == 0 || p.Y == 0 || p.X == world.Width - 1 || p.Y == world.Height - 1) // If on border
            {
                if (p.Layer == Layer.Background)
                    return false;

                return IsBasic((Foreground)p.Id);
            }

            return true;
        }

        private static bool IsBasic(Foreground id)
        {
            switch (id)
            {
                case Foregrounds.Basic.Black:
                case Foregrounds.Basic.Blue:
                case Foregrounds.Basic.Cyan:
                case Foregrounds.Basic.Gray:
                case Foregrounds.Basic.Green:
                case Foregrounds.Basic.Purple:
                case Foregrounds.Basic.Red:
                case Foregrounds.Basic.Yellow:
                    return true;

                default:
                    return false;
            }
        }
    }
}