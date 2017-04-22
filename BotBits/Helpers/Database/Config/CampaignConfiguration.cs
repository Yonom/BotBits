using System;
using PlayerIOClient;

namespace BotBits
{
    public class CampaignConfiguration : DatabaseObjectWrapper 
    {
        public CampaignConfiguration(DatabaseObject databaseObject) : base(databaseObject)
        {
        }

        public bool Enabled => this.DatabaseObject.GetBool("enabled");
    }
}
