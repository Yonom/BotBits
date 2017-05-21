using System;
using System.ComponentModel;
using System.Threading.Tasks;
using BotBits.Shop;
using PlayerIOClient;

namespace BotBits
{
    public class PlayerData
    {
        public PlayerObject PlayerObject { get; }

        public PlayerData(PlayerObject playerObject, ShopData shopData)
        {
            this.PlayerObject = playerObject;
            this.ShopData = shopData;
        }
        
        public ShopData ShopData { get; }
        
        public bool BetaMember => this.ShopData.GetCount("pro") > 0 || this.PlayerObject.OldBetaMember;

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

        internal bool HasBlockInternal(Foreground.Id id)
        {
            return this.HasPack(ItemServices.GetPackage(id));
        }

        internal bool HasBlockInternal(Background.Id id)
        {
            return this.HasPack(ItemServices.GetPackage(id));
        }

        internal bool HasBlockInternal(int id)
        {
            return this.HasPack(ItemServices.GetPackageInternal(id));
        }

        private bool HasPack(PackAttribute pack)
        {
            if (pack?.Package == null) return true;
            if (pack.AdminOnly) return this.PlayerObject.Administrator;
            if (pack.GoldMembershipItem) return this.PlayerObject.GoldMember;
            return this.ShopData.GetCount(pack.Package) > 0;
        }
    }
}