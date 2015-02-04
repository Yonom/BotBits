namespace BotBits
{
    public static class BlockExtensions
    {
        public static void Place(this Blocks blocks, int x, int y, Background block)
        {
            blocks.Place(x, y, new BackgroundBlock(block));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground block)
        {
            blocks.Place(x, y, new ForegroundBlock(block));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground block, int coinsToCollect)
        {
            blocks.Place(x, y, new ForegroundBlock(block, coinsToCollect));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground block, uint args)
        {
            blocks.Place(x, y, new ForegroundBlock(block, args));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground block, string args)
        {
            blocks.Place(x, y, new ForegroundBlock(block, args));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground block, 
            int portalId, int portalTarget, PortalRotation portalRotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground block, 
            uint portalId, uint portalTarget, PortalRotation portalRotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground block, SciFiSlopeRotation rotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, rotation));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground block, SciFiStraightRotation rotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, rotation));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground block, SpikeRotation rotation)
        {
            blocks.Place(x, y, new ForegroundBlock(block, rotation));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground block, PianoId soundId)
        {
            blocks.Place(x, y, new ForegroundBlock(block, soundId));
        }

        public static void Place(this Blocks blocks, int x, int y, Foreground block, PercussionId soundId)
        {
            blocks.Place(x, y, new ForegroundBlock(block, soundId));
        }
    }
}