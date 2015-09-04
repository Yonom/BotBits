using System;
using System.Linq;
using PlayerIOClient;

namespace BotBits
{
    class PlayerAchivements
    {
        private readonly Achievement[] _achievements;

        public PlayerAchivements(Achievement[] achievements)
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
            var ach = badge.ToString();
            return this._achievements
                .Where(a => a.Id.Equals(ach, StringComparison.OrdinalIgnoreCase))
                .Any(a => a.Completed);
        }
    }
}
