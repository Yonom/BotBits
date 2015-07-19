namespace BotBits.Events
{
    public sealed class QueueChatEvent : Event<QueueChatEvent>
    {
        public string Message { get; set; }
        public bool Cancelled { get; set; }

        public QueueChatEvent(string message)
        {
            this.Message = message;
        }
    }
}
