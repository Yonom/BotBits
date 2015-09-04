using System;
using PlayerIOClient;

namespace BotBits
{
    public static class MessageUtils
    {
        internal static Badge GetBadge(this Message message, uint index)
        {
            Badge badge;
            var badgeStr = message.GetString(index);
            if (String.IsNullOrEmpty(badgeStr)) badge = Badge.None;
            else Enum.TryParse(badgeStr, true, out badge);
            return badge;
        }
    }
}
