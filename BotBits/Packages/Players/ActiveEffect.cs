using System;

namespace BotBits
{
    public class ActiveEffect
    {
        private readonly DateTime _expireTime;

        internal ActiveEffect(Effect effect, bool expires, TimeSpan timeLeft, TimeSpan duration)
        {
            this.Effect = effect;
            this.Expires = expires;
            this.Duration = duration;
            this.Value = (int)timeLeft.TotalSeconds;

            if (this.Expires)
            {
                this._expireTime = DateTime.UtcNow.Add(timeLeft);
            }
        }
        public Effect Effect  { get; }
        public bool Expires { get; }
        public TimeSpan Duration { get; }
        public int Value { get; set; }

        public TimeSpan TimeLeft
        {
            get
            {
                if (!this.Expires)
                    throw new NotSupportedException("Cannot call TimeLeft on an effect that does not expire.");
                return DateTime.UtcNow.Subtract(this._expireTime);
            }
        }
    }
}