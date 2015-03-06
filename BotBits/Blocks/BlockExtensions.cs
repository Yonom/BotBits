using System;
using System.Collections.Generic;

namespace BotBits
{
    public static class BlockExtensions
    {
        #region Place
        public static void Place(this Blocks blocks, int x, int y, Background.Id block)
        {
            blocks.Place(x, y, new BackgroundBlock(block));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block)
        {
            blocks.Place(x, y, new ForegroundBlock(block));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, int coinsToCollect)
        {
            blocks.Place(x, y, new ForegroundBlock(block, coinsToCollect));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, uint args)
        {
            blocks.Place(x, y, new ForegroundBlock(block, args));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, string args)
        {
            blocks.Place(x, y, new ForegroundBlock(block, args));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block,
            int portalId, int portalTarget, PortalRotation portalRotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block,
            uint portalId, uint portalTarget, PortalRotation portalRotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, SciFiSlopeRotation rotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, rotation));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, SciFiStraightRotation rotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, rotation));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, BlockRotation rotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, rotation));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, PianoId soundId)
        {
            blocks.Place(x, y, new ForegroundBlock(block, soundId));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, PercussionId soundId)
        {
            blocks.Place(x, y, new ForegroundBlock(block, soundId));
        }
        #endregion

        #region FillWith IEnumerable

        public static void FillWith(this IEnumerable<BlocksItem> blocks, ForegroundBlock block)
        {
            foreach (var item in blocks)
                item.Place(block);
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, BackgroundBlock block)
        {
            foreach (var item in blocks)
                item.Place(block);
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, Background.Id block)
        {
            blocks.FillWith(new BackgroundBlock(block));
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, Foreground.Id block)
        {
            blocks.FillWith(new ForegroundBlock(block));
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, Foreground.Id block, int coinsToCollect)
        {
            blocks.FillWith(new ForegroundBlock(block, coinsToCollect));
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, Foreground.Id block, uint args)
        {
            blocks.FillWith(new ForegroundBlock(block, args));
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, Foreground.Id block, string args)
        {
            blocks.FillWith(new ForegroundBlock(block, args));
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, Foreground.Id block,
            int portalId, int portalTarget, PortalRotation portalRotation)
        {
            blocks.FillWith(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, Foreground.Id block,
            uint portalId, uint portalTarget, PortalRotation portalRotation)
        {
            blocks.FillWith(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, Foreground.Id block, SciFiSlopeRotation rotation)
        {
            blocks.FillWith(new ForegroundBlock(block, rotation));
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, Foreground.Id block, SciFiStraightRotation rotation)
        {
            blocks.FillWith(new ForegroundBlock(block, rotation));
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, Foreground.Id block, BlockRotation rotation)
        {
            blocks.FillWith(new ForegroundBlock(block, rotation));
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, Foreground.Id block, PianoId soundId)
        {
            blocks.FillWith(new ForegroundBlock(block, soundId));
        }

        public static void FillWith(this IEnumerable<BlocksItem> blocks, Foreground.Id block, PercussionId soundId)
        {
            blocks.FillWith(new ForegroundBlock(block, soundId));
        }
        #endregion

        #region Place IBlockSettable
        public static void Place(this BlocksItem blocks, Background.Id block)
        {
            blocks.Place(new BackgroundBlock(block));
        }

        public static void Place(this BlocksItem blocks, Foreground.Id block)
        {
            blocks.Place(new ForegroundBlock(block));
        }

        public static void Place(this BlocksItem blocks, Foreground.Id block, int coinsToCollect)
        {
            blocks.Place(new ForegroundBlock(block, coinsToCollect));
        }

        public static void Place(this BlocksItem blocks, Foreground.Id block, uint args)
        {
            blocks.Place(new ForegroundBlock(block, args));
        }

        public static void Place(this BlocksItem blocks, Foreground.Id block, string args)
        {
            blocks.Place(new ForegroundBlock(block, args));
        }

        public static void Place(this BlocksItem blocks, Foreground.Id block,
            int portalId, int portalTarget, PortalRotation portalRotation)
        {
            blocks.Place(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Place(this BlocksItem blocks, Foreground.Id block,
            uint portalId, uint portalTarget, PortalRotation portalRotation)
        {
            blocks.Place(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Place(this BlocksItem blocks, Foreground.Id block, SciFiSlopeRotation rotation)
        {
            blocks.Place(new ForegroundBlock(block, rotation));
        }

        public static void Place(this BlocksItem blocks, Foreground.Id block, SciFiStraightRotation rotation)
        {
            blocks.Place(new ForegroundBlock(block, rotation));
        }

        public static void Place(this BlocksItem blocks, Foreground.Id block, BlockRotation rotation)
        {
            blocks.Place(new ForegroundBlock(block, rotation));
        }

        public static void Place(this BlocksItem blocks, Foreground.Id block, PianoId soundId)
        {
            blocks.Place(new ForegroundBlock(block, soundId));
        }

        public static void Place(this BlocksItem blocks, Foreground.Id block, PercussionId soundId)
        {
            blocks.Place(new ForegroundBlock(block, soundId));
        }
        #endregion
    }
}