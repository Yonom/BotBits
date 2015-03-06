using System;
using System.Collections.Generic;

namespace BotBits
{
    public static class BlockExtensions
    {
        #region Place
        public static void Set(this Blocks blocks, int x, int y, Background.Id block)
        {
            blocks.Place(x, y, new BackgroundBlock(block));
        }

        public static void Set(this Blocks blocks, int x, int y, Foreground.Id block)
        {
            blocks.Place(x, y, new ForegroundBlock(block));
        }

        public static void Set(this Blocks blocks, int x, int y, Foreground.Id block, int coinsToCollect)
        {
            blocks.Place(x, y, new ForegroundBlock(block, coinsToCollect));
        }

        public static void Set(this Blocks blocks, int x, int y, Foreground.Id block, uint args)
        {
            blocks.Place(x, y, new ForegroundBlock(block, args));
        }

        public static void Set(this Blocks blocks, int x, int y, Foreground.Id block, string args)
        {
            blocks.Place(x, y, new ForegroundBlock(block, args));
        }

        public static void Set(this Blocks blocks, int x, int y, Foreground.Id block,
            int portalId, int portalTarget, PortalRotation portalRotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set(this Blocks blocks, int x, int y, Foreground.Id block,
            uint portalId, uint portalTarget, PortalRotation portalRotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set(this Blocks blocks, int x, int y, Foreground.Id block, SciFiSlopeRotation rotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, rotation));
        }

        public static void Set(this Blocks blocks, int x, int y, Foreground.Id block, SciFiStraightRotation rotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, rotation));
        }

        public static void Set(this Blocks blocks, int x, int y, Foreground.Id block, BlockRotation rotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, rotation));
        }

        public static void Set(this Blocks blocks, int x, int y, Foreground.Id block, PianoId soundId)
        {
            blocks.Place(x, y, new ForegroundBlock(block, soundId));
        }

        public static void Set(this Blocks blocks, int x, int y, Foreground.Id block, PercussionId soundId)
        {
            blocks.Place(x, y, new ForegroundBlock(block, soundId));
        }
        #endregion

        #region FillWith IEnumerable

        public static void Set(this IEnumerable<BlocksItem> blocks, ForegroundBlock block)
        {
            foreach (var item in blocks)
                item.Set(block);
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, BackgroundBlock block)
        {
            foreach (var item in blocks)
                item.Set(block);
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Background.Id block)
        {
            blocks.Set(new BackgroundBlock(block));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block)
        {
            blocks.Set(new ForegroundBlock(block));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, int coinsToCollect)
        {
            blocks.Set(new ForegroundBlock(block, coinsToCollect));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, uint args)
        {
            blocks.Set(new ForegroundBlock(block, args));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, string args)
        {
            blocks.Set(new ForegroundBlock(block, args));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block,
            int portalId, int portalTarget, PortalRotation portalRotation)
        {
            blocks.Set(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block,
            uint portalId, uint portalTarget, PortalRotation portalRotation)
        {
            blocks.Set(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, SciFiSlopeRotation rotation)
        {
            blocks.Set(new ForegroundBlock(block, rotation));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, SciFiStraightRotation rotation)
        {
            blocks.Set(new ForegroundBlock(block, rotation));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, BlockRotation rotation)
        {
            blocks.Set(new ForegroundBlock(block, rotation));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, PianoId soundId)
        {
            blocks.Set(new ForegroundBlock(block, soundId));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, PercussionId soundId)
        {
            blocks.Set(new ForegroundBlock(block, soundId));
        }
        #endregion

        #region Place IBlockSettable
        public static void Set(this BlocksItem blocks, Background.Id block)
        {
            blocks.Set(new BackgroundBlock(block));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block)
        {
            blocks.Set(new ForegroundBlock(block));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block, int coinsToCollect)
        {
            blocks.Set(new ForegroundBlock(block, coinsToCollect));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block, uint args)
        {
            blocks.Set(new ForegroundBlock(block, args));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block, string args)
        {
            blocks.Set(new ForegroundBlock(block, args));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block,
            int portalId, int portalTarget, PortalRotation portalRotation)
        {
            blocks.Set(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block,
            uint portalId, uint portalTarget, PortalRotation portalRotation)
        {
            blocks.Set(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block, SciFiSlopeRotation rotation)
        {
            blocks.Set(new ForegroundBlock(block, rotation));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block, SciFiStraightRotation rotation)
        {
            blocks.Set(new ForegroundBlock(block, rotation));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block, BlockRotation rotation)
        {
            blocks.Set(new ForegroundBlock(block, rotation));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block, PianoId soundId)
        {
            blocks.Set(new ForegroundBlock(block, soundId));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block, PercussionId soundId)
        {
            blocks.Set(new ForegroundBlock(block, soundId));
        }
        #endregion
    }
}