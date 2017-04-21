using System;
using System.ComponentModel;
using System.Threading.Tasks;
using BotBits.SendMessages;
using BotBits.Shop;
using PlayerIOClient;

namespace BotBits
{
    public class UsernameData
    {
        private readonly DatabaseObject _databaseObject;

        public UsernameData(DatabaseObject databaseObject)
        {
            this._databaseObject = databaseObject;
        }

        public string Owner => this._databaseObject.GetString("owner", null);
        public string OldOwner => this._databaseObject.GetString("old_owner", null);
        public string Username => this._databaseObject.Key;

    }
}