using System.Collections.Generic;
using BotBits.Shop;
using PlayerIOClient;

namespace BotBits
{
    public class ShopData
    {
        public int Gems { get; }
        private readonly Dictionary<string, int> _itemCounts = new Dictionary<string, int>();

        public ShopData(int gems, IEnumerable<VaultItem> items)
        {
            this.Gems = gems;

            foreach (var item in items)
            {
                int count;
                this._itemCounts.TryGetValue(item.ItemKey, out count);
                this._itemCounts[item.ItemKey] = count + 1;
            }
        }

        public int GetCount(string pack)
        {
            int owned;
            this._itemCounts.TryGetValue(pack, out owned);
            return owned;
        }
    }
}