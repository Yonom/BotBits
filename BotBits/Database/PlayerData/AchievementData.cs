using System;
using System.Linq;
using PlayerIOClient;

namespace BotBits
{
    public class AchievementData
    {
        private readonly Achievement[] _achievements;

        public AchievementData(Achievement[] achievements)
        {
            this._achievements = achievements;
        }

        public Badge[] GetBadges()
        {
            return this._achievements
                .Where(a => a.Completed)
                .Select(a =>
                {
                    Badge badge;
                    Enum.TryParse(a.Id, true, out badge);
                    return badge;
                })
                .ToArray();
        }

        public bool HasBadge(Badge badge)
        {
            if (badge == Badge.None) return true;
            if (badge == Badge.Unknown) throw new NotSupportedException("Unknown Badge given.");

            var ach = badge.ToString();
            return this._achievements
                .Where(a => a.Id.Equals(ach, StringComparison.OrdinalIgnoreCase))
                .Any(a => a.Completed);
        }
    }
}