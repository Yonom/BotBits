using JetBrains.Annotations;
using BotBits.Events;

namespace BotBits
{
    public static class PlayerUtils
    {
        /// <summary>
        ///     Determines whether the player with the specified username is a guest.
        /// </summary>
        /// <param name="username">The player's username.</param>
        /// <returns></returns>
        [Pure]
        public static bool IsGuest(string username)
        {
            // Official implementation in SWF, don't blame me
            return username.Contains("-");
        }

        /// <summary>
        ///     Gets the chat name of the specified player.
        /// </summary>
        /// <param name="username">The player's username.</param>
        /// <returns></returns>
        [Pure]
        public static string GetChatName(string username)
        {
            return username.ToUpperInvariant();
        }
    }
}