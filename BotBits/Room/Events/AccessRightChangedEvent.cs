namespace BotBits.Events
{
    public sealed class AccessRightChangedEvent : Event<AccessRightChangedEvent>
    {
        internal AccessRightChangedEvent(AccessRight newRights)
        {
            this.NewRights = newRights;
        }

        public AccessRight NewRights { get; private set; }
    }
}