using System;

namespace BotBits
{
    public sealed class MetadataChangedEventArgs : EventArgs
    {
        internal MetadataChangedEventArgs(string key, object oldValue, object newValue)
        {
            this.Key = key;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        public string Key { get; private set; }
        public object OldValue { get; private set; }
        public object NewValue { get; private set; }
    }
}