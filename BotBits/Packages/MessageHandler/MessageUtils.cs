using System;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    internal static class MessageUtils
    {
        public static Badge GetBadge(this Message message, uint index)
        {
            Badge badge;
            var badgeStr = message.GetString(index);
            if (string.IsNullOrEmpty(badgeStr)) badge = Badge.None;
            else Enum.TryParse(badgeStr, true, out badge);
            return badge;
        }
    }
}