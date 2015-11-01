using System.Collections.Generic;
using PlayerIOClient;

namespace BotBits
{
    public class ShopData
    {
        private readonly Dictionary<string, int> _itemCounts = new Dictionary<string, int>();

        public ShopData(IEnumerable<VaultItem> items)
        {
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