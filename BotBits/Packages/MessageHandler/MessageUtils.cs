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

        public static Point3D GetPoint3D(this PlaceSendMessage placeSendMessage)
        {
            return new Point3D(placeSendMessage.Layer, placeSendMessage.X, placeSendMessage.Y);
        }
    }
}