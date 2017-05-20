using System.Collections.Generic;

namespace BotBits
{
    public static class BlockSettableExtensions
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

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, string text, string textColor, int wrapWidth)
        {
            blocks.Place(x, y, new ForegroundBlock(block, text, textColor, wrapWidth));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, string text, string textColor, uint wrapWidth)
        {
            blocks.Place(x, y, new ForegroundBlock(block, text, textColor, wrapWidth));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground.Id block, string text, Morph.Id signColor)
        {
            blocks.Place(x, y, new ForegroundBlock(block, text, signColor));
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

        #region BlocksItem

        public static void Set(this IBlockSettable<ForegroundBlock, BackgroundBlock> blocks, Background.Id block)
        {
            blocks.Set(new BackgroundBlock(block));
        }

        public static void Set(this IBlockSettable<ForegroundBlock, BackgroundBlock> blocks, Foreground.Id block)
        {
            blocks.Set(new ForegroundBlock(block));
        }

        public static void Set(this IBlockSettable<ForegroundBlock, BackgroundBlock> blocks, Foreground.Id block, int goal)
        {
            blocks.Set(new ForegroundBlock(block, goal));
        }

        public static void Set(this IBlockSettable<ForegroundBlock, BackgroundBlock> blocks, Foreground.Id block, uint args)
        {
            blocks.Set(new ForegroundBlock(block, args));
        }

        public static void Set(this IBlockSettable<ForegroundBlock, BackgroundBlock> blocks, Foreground.Id block, string args)
        {
            blocks.Set(new ForegroundBlock(block, args));
        }

        public static void Set(this IBlockSettable<ForegroundBlock, BackgroundBlock> blocks, Foreground.Id block, string text, string textColor, int wrapWidth)
        {
            blocks.Set(new ForegroundBlock(block, text, textColor, wrapWidth));
        }

        public static void Set(this IBlockSettable<ForegroundBlock, BackgroundBlock> blocks, Foreground.Id block, string text, string textColor, uint wrapWidth)
        {
            blocks.Set(new ForegroundBlock(block, text, textColor, wrapWidth));
        }

        public static void Set(this IBlockSettable<ForegroundBlock, BackgroundBlock> blocks, Foreground.Id block, string text, Morph.Id signColor)
        {
            blocks.Set(new ForegroundBlock(block, text, signColor));
        }

        public static void Set(this IBlockSettable<ForegroundBlock, BackgroundBlock> blocks, Foreground.Id block,
            int portalId, int portalTarget, Morph.Id portalRotation)
        {
            blocks.Set(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set(this IBlockSettable<ForegroundBlock, BackgroundBlock> blocks, Foreground.Id block,
            uint portalId, uint portalTarget, Morph.Id portalRotation)
        {
            blocks.Set(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set(this IBlockSettable<ForegroundBlock, BackgroundBlock> blocks, Foreground.Id block, Morph.Id morph)
        {
            blocks.Set(new ForegroundBlock(block, morph));
        }

        public static void Set(this IBlockSettable<ForegroundBlock, BackgroundBlock> blocks, Foreground.Id block, bool enabled)
        {
            blocks.Set(new ForegroundBlock(block, enabled));
        }

        #endregion

        #region IEnumerable Of BlocksItem

        public static void Set<T>(this IEnumerable<T> blocks, ForegroundBlock block) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            foreach (var item in blocks) item.Set(block);
        }

        public static void Set<T>(this IEnumerable<T> blocks, BackgroundBlock block) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            foreach (var item in blocks) item.Set(block);
        }

        public static void Set<T>(this IEnumerable<T> blocks, Background.Id block) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.Set(new BackgroundBlock(block));
        }

        public static void Set<T>(this IEnumerable<T> blocks, Foreground.Id block) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.Set(new ForegroundBlock(block));
        }

        public static void Set<T>(this IEnumerable<T> blocks, Foreground.Id block, int goal) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.Set(new ForegroundBlock(block, goal));
        }

        public static void Set<T>(this IEnumerable<T> blocks, Foreground.Id block, uint args) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.Set(new ForegroundBlock(block, args));
        }

        public static void Set<T>(this IEnumerable<T> blocks, Foreground.Id block, string args) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.Set(new ForegroundBlock(block, args));
        }

        public static void Set<T>(this IEnumerable<T> blocks, Foreground.Id block, string text, string textColor, int wrapWidth) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.Set(new ForegroundBlock(block, text, textColor, wrapWidth));
        }

        public static void Set<T>(this IEnumerable<T> blocks, Foreground.Id block, string text, string textColor, uint wrapWidth) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.Set(new ForegroundBlock(block, text, textColor, wrapWidth));
        }

        public static void Set<T>(this IEnumerable<T> blocks, Foreground.Id block, string text, Morph.Id signColor) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.Set(new ForegroundBlock(block, text, signColor));
        }

        public static void Set<T>(this IEnumerable<T> blocks, Foreground.Id block,
            int portalId, int portalTarget, Morph.Id portalRotation) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.Set(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set<T>(this IEnumerable<T> blocks, Foreground.Id block,
            uint portalId, uint portalTarget, Morph.Id portalRotation) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.Set(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Set<T>(this IEnumerable<T> blocks, Foreground.Id block, Morph.Id morph) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.Set(new ForegroundBlock(block, morph));
        }

        public static void Set<T>(this IEnumerable<T> blocks, Foreground.Id block, bool enabled) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.Set(new ForegroundBlock(block, enabled));
        }

        #endregion
        
        #region IEnumerable Of IEnumerable Of BlocksItem

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, ForegroundBlock block) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            foreach (var item in blocks)
                item.Set(block);
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, BackgroundBlock block) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            foreach (var item in blocks)
                item.Set(block);
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, Background.Id block) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.SetMany(new BackgroundBlock(block));
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, Foreground.Id block) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.SetMany(new ForegroundBlock(block));
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, Foreground.Id block, int goal) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.SetMany(new ForegroundBlock(block, goal));
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, Foreground.Id block, uint args) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.SetMany(new ForegroundBlock(block, args));
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, Foreground.Id block, string args) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.SetMany(new ForegroundBlock(block, args));
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, Foreground.Id block, string text, string textColor, int wrapWidth) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.SetMany(new ForegroundBlock(block, text, textColor, wrapWidth));
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, Foreground.Id block, string text, string textColor, uint wrapWidth) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.SetMany(new ForegroundBlock(block, text, textColor, wrapWidth));
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, Foreground.Id block, string text, Morph.Id signColor) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.SetMany(new ForegroundBlock(block, text, signColor));
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, Foreground.Id block,
            int portalId, int portalTarget, Morph.Id portalRotation) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.SetMany(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, Foreground.Id block,
            uint portalId, uint portalTarget, Morph.Id portalRotation) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.SetMany(new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, Foreground.Id block, Morph.Id morph) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.SetMany(new ForegroundBlock(block, morph));
        }

        public static void SetMany<T>(this IEnumerable<IEnumerable<T>> blocks, Foreground.Id block, bool enabled) where T : IBlockSettable<ForegroundBlock, BackgroundBlock>
        {
            blocks.SetMany(new ForegroundBlock(block, enabled));
        }

        #endregion
    }
}