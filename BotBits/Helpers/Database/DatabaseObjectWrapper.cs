using System;
using System.ComponentModel;
using PlayerIOClient;

namespace BotBits
{
    public abstract class DatabaseObjectWrapper
    {
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public DatabaseObject DatabaseObject { get; }

        protected DatabaseObjectWrapper(DatabaseObject databaseObject)
        {
            this.DatabaseObject = databaseObject;
        }
    }
}
