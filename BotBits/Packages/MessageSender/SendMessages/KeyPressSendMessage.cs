using System;
using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to activate blue key.
    /// </summary>
    public sealed class KeyPressSendMessage : SendMessage<KeyPressSendMessage>
    {
        public KeyPressSendMessage(Key key) : this(key.ToString().ToLower())
        {
        }

        public KeyPressSendMessage(string key)
        {
            this.Key = key;
        }

        public KeyPressSendMessage(Key key, int x, int y) : this(key.ToString().ToLower(), x, y)
        {
            if (key == BotBits.Key.TimeDoor) throw new InvalidOperationException("TimeDoors are not a pressable key type.");
        }

        public KeyPressSendMessage(string key, int x, int y) : this(key)
        {
            this.X = x;
            this.Y = y;
        }

        public string Key { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("pressKey", this.X, this.Y, this.Key);
        }
    }
}