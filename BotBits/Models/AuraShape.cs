using BotBits.Shop;

namespace BotBits
{
    public enum AuraShape
    {
        Default = 0,

        [Pack("aurashapepinwheel")]
        PinWheel = 1,

        [Pack("aurashapetorus")]
        Torus = 2,

        [Pack("-", GoldMembershipItem = true)]
        Gold
    }
}
