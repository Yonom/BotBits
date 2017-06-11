using System;
using System.ComponentModel;
using System.Threading.Tasks;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    public class VersionConfiguration : DatabaseObjectWrapper
    {
        public VersionConfiguration(DatabaseObject databaseObject) : base(databaseObject)
        {
        }

        public int Version => this.DatabaseObject.GetInt("version");
        public int NextVersion => this.DatabaseObject.GetInt("nextversion");
        public int BetaVersion => this.DatabaseObject.GetInt("betaversion");
        public DateTime Scheduled => this.DatabaseObject.GetDateTime("scheduled");
    }
}