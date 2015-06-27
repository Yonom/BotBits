namespace BotBits
{
    /// <summary>
    /// Represents the types a <see cref="Foreground" /> can be.
    /// </summary>
    public enum ForegroundType : byte
    {
        /// <summary>
        ///     A normal block
        /// </summary>
        Normal,

        /// <summary>
        ///      A toggle block
        /// </summary>
        Toggle,

        /// <summary>
        ///     A coin door block
        /// </summary>
        Team,

        /// <summary>
        ///     A coin door block
        /// </summary>
        Goal,

        /// <summary>
        ///     A portal block
        /// </summary>
        Portal,

        /// <summary>
        ///     A label block
        /// </summary>
        Label,

        /// <summary>
        ///     A world portal block
        /// </summary>
        Text,

        /// <summary>
        ///     A piano block
        /// </summary>
        Note,

        /// <summary>
        ///     A morphable block
        /// </summary>
        Morphable,

        /// <summary>
        ///     A world portal block
        /// </summary>
        WorldPortal
    }
}