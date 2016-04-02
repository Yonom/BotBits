using BotBits.Shop;

namespace BotBits
{
    public class PlayerData
    {
        public PlayerData(PlayerObject playerObject, ShopData shopData)
        {
            this.PlayerObject = playerObject;
            this.ShopData = shopData;
        }

        public PlayerObject PlayerObject { get; }
        public ShopData ShopData { get; }

        public bool HasSmiley(Smiley smiley)
        {
            return this.HasPack(ItemServices.GetPackage(smiley));
        }

        public bool HasAuraColor(AuraColor auraColor)
        {
            return this.HasPack(ItemServices.GetPackage(auraColor));
        }

        public bool HasAuraShape(AuraShape auraShape)
        {
            return this.HasPack(ItemServices.GetPackage(auraShape));
        }

        private bool HasPack(PackAttribute pack)
        {
            if (pack == null) return true;
            if (pack.AdminOnly) return this.PlayerObject.IsAdministrator;
            if (pack.GoldMembershipItem) return this.PlayerObject.ClubMember;
            return this.ShopData.GetCount(pack.Package) > 0;
        }
        
        public bool HasBlock(int id)
        {
            return this.HasPack(ItemServices.GetPackageInternal(id));
        }
    }
}