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
        Gold = 3,

        [Pack("aurashapespiral")]
        Spiral = 4,

        [Pack("aurashapestar")]
        Star = 5,
        
        [Pack("aurashapesnowflake")]
        Snowflake = 6
    }
}
