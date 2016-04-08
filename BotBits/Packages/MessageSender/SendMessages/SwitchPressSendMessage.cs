using BotBits.Models;
using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change purple switch state.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class SwitchPressSendMessage : SendMessage<SwitchPressSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PlaceSendMessage" /> class.
        /// </summary>
        public SwitchPressSendMessage(SwitchType switchType, int id, bool enabled, int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.SwitchType = switchType;
            this.Id = id;
            this.Enabled = enabled;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public SwitchType SwitchType { get; set; }
        public int Id { get; set; }
        public bool Enabled { get; set; }


        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("ps", this.X, this.Y, (int)this.SwitchType, this.Id, this.Enabled);
        }
    }
}