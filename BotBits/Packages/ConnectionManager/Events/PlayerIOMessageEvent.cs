using PlayerIOClient;

namespace BotBits.Events
{
    public sealed class PlayerIOMessageEvent : Event<PlayerIOMessageEvent>
    {
        internal PlayerIOMessageEvent(Message message)
        {
            this.Message = message;
        }

        public Message Message { get; private set; }
    }
}
