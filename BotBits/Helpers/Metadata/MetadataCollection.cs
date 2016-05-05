using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BotBits
{
    public abstract class MetadataCollection
    {
        private readonly ConcurrentDictionary<string, object> _metadatas = new ConcurrentDictionary<string, object>();

        public event EventHandler<MetadataChangedEventArgs> MetadataChanged;

        private void OnMetadataChanged(MetadataChangedEventArgs e)
        {
            var handler = this.MetadataChanged;
            if (handler != null) handler(this, e);
        }

        public virtual T Get<T>(string id)
        {
            T value;
            this.GetMetadata(id, out value);
            return value;
        }

        public virtual void Set<T>(string id, T value)
        {
            while (!this.SetMetadata(id, value))
            {
            }
        }

        private void GetMetadata<TMetadata>(string metadataId, out TMetadata metadata)
        {
            object metadataObj;
            this._metadatas.TryGetValue(metadataId, out metadataObj);

            metadata = default(TMetadata);
            if (metadataObj != null) metadata = (TMetadata)metadataObj;
        }

        private bool SetMetadata<TMetaData>(string metadataId, TMetaData value)
        {
            object oldObj = default(TMetaData);
            var newObj = (TMetaData)this._metadatas.AddOrUpdate(metadataId, value, (k, v) =>
            {
                oldObj = v;
                return value;
            });
            if (!EqualityComparer<TMetaData>.Default.Equals(newObj, value)) return false; // There was another insert at the same time

            this.OnMetadataChanged(new MetadataChangedEventArgs(metadataId, oldObj, newObj));
            return true;
        }
    }
}