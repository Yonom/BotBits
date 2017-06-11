using System;
using System.ComponentModel;
using System.Threading.Tasks;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    public class UsernameData : DatabaseObjectWrapper
    {
        public UsernameData(DatabaseObject databaseObject) : base(databaseObject)
        {
        }

        public string Owner => this.DatabaseObject.GetString("owner", null);
        public string OldOwner => this.DatabaseObject.GetString("old_owner", null);
        public string Username => this.DatabaseObject.Key;
    }
}