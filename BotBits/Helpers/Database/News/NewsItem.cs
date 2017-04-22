using PlayerIOClient;

namespace BotBits
{
    public class NewsItem : DatabaseObjectWrapper
    {
        public NewsItem(DatabaseObject databaseObject) : base(databaseObject)
        {
        }

        public string Id => this.DatabaseObject.Key;

        public bool Enabled => this.DatabaseObject.GetBool("enabled", false);
        public string Header => this.DatabaseObject.GetString("header", null);
        public string Body => this.DatabaseObject.GetString("body", null);
        public string Date => this.DatabaseObject.GetString("date", null);
        public string Image => this.DatabaseObject.GetString("image", null);
    }
}
