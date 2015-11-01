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

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, int goal)
        {
            blocks.Place(x, y, new ForegroundBlock(block, goal));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, uint args)
        {
            blocks.Place(x, y, new ForegroundBlock(block, args));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, string args)
        {
            blocks.Place(x, y, new ForegroundBlock(block, args));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, string text, string textColor)
        {
            blocks.Place(x, y, new ForegroundBlock(block, text, textColor));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block,
            int portalId, int portalTarget, Morph.Id portalRotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block,
            uint portalId, uint portalTarget, Morph.Id portalRotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, Morph.Id morph)
        {
            blocks.Place(x, y, new ForegroundBlock(block, morph));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, bool enabled)
        {
            blocks.Place(x, y, new ForegroundBlock(block, enabled));
        }

        #endregion

        #region BlocksItem IEnumerable

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

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, int goal)
        {
            blocks.Set(new ForegroundBlock(block, goal));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, uint args)
        {
            blocks.Set(new ForegroundBlock(block, args));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, string args)
        {
            blocks.Set(new ForegroundBlock(block, args));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, string text, string textColor)
        {
            blocks.Set(new ForegroundBlock(block, text, textColor));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block,
            int portalId, int portalTarget, Morph.Id portalRotation)
        {
            blocks.Set(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block,
            uint portalId, uint portalTarget, Morph.Id portalRotation)
        {
            blocks.Set(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, Morph.Id morph)
        {
            blocks.Set(new ForegroundBlock(block, morph));
        }

        public static void Set(this IEnumerable<BlocksItem> blocks, Foreground.Id block, bool enabled)
        {
            blocks.Set(new ForegroundBlock(block, enabled));
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

        public static void Set(this BlocksItem blocks, Foreground.Id block, int goal)
        {
            blocks.Set(new ForegroundBlock(block, goal));
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
            int portalId, int portalTarget, Morph.Id portalRotation)
        {
            blocks.Set(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block,
            uint portalId, uint portalTarget, Morph.Id portalRotation)
        {
            blocks.Set(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block, Morph.Id morph)
        {
            blocks.Set(new ForegroundBlock(block, morph));
        }

        public static void Set(this BlocksItem blocks, Foreground.Id block, bool enabled)
        {
            blocks.Set(new ForegroundBlock(block, enabled));
        }

        #endregion
    }
}