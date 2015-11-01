using System;
using System.Collections.Generic;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    internal static class MessageUtils
    {
        public static int[] GetSwitches(byte[] switchData)
        {
            var switches = new List<int>();
            for (var i = 0; i < switchData.Length; i++)
            {
                if (switchData[i] == 0) continue;
                switches.Add(i);
            }
            return switches.ToArray();
        }

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