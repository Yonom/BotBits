namespace BotBits
{
    /// <summary>
    ///     Represents the rights of the bot connection in the world.
    /// </summary>
    public enum AccessRight
    {
        /// <summary>
        ///     Represents the state where the bot doesn't have any rights in the world.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Represents the state where the bot can change world options.
        /// </summary>
        WorldOptions = 1,

        /// <summary>
        ///     Represents the state where bot has command access and edit rights in the world.
        /// </summary>
        Owner = 2
    }
}