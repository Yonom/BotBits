using BotBits.Shop;

namespace BotBits
{
    public enum Aura
    {
        Normal = 0,

        [Pack("aurared")] Red = 1,
        [Pack("aurablue")] Blue = 2,
        [Pack("aurayellow")] Yellow = 3,
        [Pack("auragreen")] Green = 4,
        [Pack("aurapurple")] Purple = 5,
        [Pack("-", BuildersClubOnly = true)] BcNormal = 6,
        [Pack("aurared", BuildersClubOnly = true)] BcRed = 7,
        [Pack("aurablue", BuildersClubOnly = true)] BcBlue = 8,
        [Pack("aurayellow", BuildersClubOnly = true)] BcYellow = 9,
        [Pack("auragreen", BuildersClubOnly = true)] BcGreen = 10,
        [Pack("aurapurple", BuildersClubOnly = true)] BcPurple = 11,

        [Pack("auraorange")] Orange = 12,
        [Pack("auraorange", BuildersClubOnly = true)] BcOrange = 13
    }
}