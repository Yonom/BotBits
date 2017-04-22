using PlayerIOClient;

namespace BotBits
{
    public class ShopItem : DatabaseObjectWrapper
    {

        public ShopItem(DatabaseObject databaseObject) : base(databaseObject)
        {
        }

        public string Id => this.DatabaseObject.Key;

        public int PriceGems => this.DatabaseObject.GetInt("PriceCoins");
        public int PriceEnergy => this.DatabaseObject.GetInt("PriceEnergy", -1);
        public int EnergyPerClick => this.DatabaseObject.GetInt("EnergyPerClick", 5);
        
        public bool Reusable => this.DatabaseObject.GetBool("Reusable", false);
        public int MaxPurchases => this.DatabaseObject.GetInt("MaxPurchases", 0);
        public bool BetaOnly => this.DatabaseObject.GetBool("BetaOnly", false);

        public int AvailableSince => this.DatabaseObject.GetInt("AvailableSince", 0);

        public bool New => this.DatabaseObject.GetBool("IsNew", false);
        public bool Featured => this.DatabaseObject.GetBool("IsFeatured", false);
        public bool Enabled => this.DatabaseObject.GetBool("Enabled", false);

        public bool Classic => this.DatabaseObject.GetBool("IsClassic", false);
        public bool OnSale => this.DatabaseObject.GetBool("OnSale", false);
        public int Span => this.DatabaseObject.GetInt("Span", 1);
        public string Header => this.DatabaseObject.GetString("Header", "");
        public string Body => this.DatabaseObject.GetString("Body", "");
        public string BitmapSheetId => this.DatabaseObject.GetString("BitmapSheetId", null);
        public int BitmapSheetOffset => this.DatabaseObject.GetInt("BitmapSheetOffset", 0);
        public bool PlayerWorldOnly => this.DatabaseObject.GetBool("PWOnly", false);
        public bool DevOnly => this.DatabaseObject.GetBool("DevOnly", false);
        public bool GridFeatured => this.DatabaseObject.GetBool("IsGridFeatured", false);
        public int PriceUsd => this.DatabaseObject.GetInt("PriceUSD", -1);
        public string Label => this.DatabaseObject.GetString("Label", "");
        public string LabelColor => this.DatabaseObject.GetString("LabelColor", "#FFAA00");
    }
}
