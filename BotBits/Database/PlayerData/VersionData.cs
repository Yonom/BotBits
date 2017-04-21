using System;
using System.ComponentModel;
using System.Threading.Tasks;
using BotBits.SendMessages;
using BotBits.Shop;
using PlayerIOClient;

namespace BotBits
{
    public class VersionData
    {
        private readonly DatabaseObject _databaseObject;

        public VersionData(DatabaseObject databaseObject)
        {
            this._databaseObject = databaseObject;
        }

        public int Version => this._databaseObject.GetInt("version");
        public int NextVersion => this._databaseObject.GetInt("nextversion");
        public int BetaVersion => this._databaseObject.GetInt("betaversion");
        public DateTime Scheduled => this._databaseObject.GetDateTime("scheduled");
    }
}