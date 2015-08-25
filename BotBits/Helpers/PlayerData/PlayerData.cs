using BotBits.Shop;

namespace BotBits
{
    public class PlayerData
    {
        public PlayerObject PlayerObject { get; private set; }
        public ShopData ShopData { get; private set; }

        public PlayerData(PlayerObject playerObject, ShopData shopData)
        {
            this.PlayerObject = playerObject;
            this.ShopData = shopData;
        }

        public bool HasSmiley(Smiley smiley)
        {
            return this.HasPack(ItemServices.GetPackage(smiley));
        }

        public bool HasAura(Aura aura)
        {
            return this.HasPack(ItemServices.GetPackage(aura));
        }

        private bool HasPack(PackAttribute pack)
        {
            if (pack == null) return true;

            return this.ShopData.GetCount(pack.Package) > 0 && 
                (!pack.BuildersClubOnly || this.PlayerObject.ClubMember);
        }


        public bool HasBlock(int id, int count)
        {
            var pack = ItemServices.GetPackageInternal(id);
            if (pack == null) return true;

            //if (pack.BlocksPerPack > 0)
            //{
            //    int owned;
            //    this._itemCounts.TryGetValue(pack.Package, out owned);
            //    return (isBuildersClub && pack.Package != "brickdiamond") || 
            //           pack.BlocksPerPack * owned > count;
            //}

            switch (pack.Package)
            {
                case "admin":
                    return this.PlayerObject.IsAdministrator;
                case "brickdiamond":
                case "brickhwthrophy":
                case "brickmagic":
                case "brickmagic2":
                case "brickmagic3":
                case "brickmagic4":
                case "brickmagic5":
                    goto check;
                default:
                    if (this.PlayerObject.ClubMember) return true;
                    if (pack.BuildersClubOnly) return false;
                check:
                    return this.ShopData.GetCount(pack.Package) > 0;
            }
        }
    }
}
