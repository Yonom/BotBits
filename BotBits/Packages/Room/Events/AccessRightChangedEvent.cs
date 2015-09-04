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

    public sealed class EditRightChangedEvent : Event<EditRightChangedEvent>
    {
        internal EditRightChangedEvent(bool canEdit)
        {
            this.CanEdit = canEdit;
        }

        public bool CanEdit { get; private set; }
    }
}