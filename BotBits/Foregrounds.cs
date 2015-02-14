// ReSharper disable MemberHidesStaticFromOuterClass
namespace BotBits
{
    public static class Foregrounds
    {
        public const Foreground
            Empty = Gravity.Down;

        public static class Gravity
        {
            public const Foreground
                Down = 0,
                Left = (Foreground)1,
                Up = (Foreground)2,
                Right = (Foreground)3,
                Dot = (Foreground)4,
                InvisibleLeft = (Foreground)411,
                InvisibleUp = (Foreground)412,
                InvisibleRight = (Foreground)413,
                InvisibleDot = (Foreground)414;
        }

        public static class Crown
        {
            public const Foreground
                Gold = (Foreground)5;
        }

        public static class Key
        {
            public const Foreground
                Red = (Foreground)6,
                Green = (Foreground)7,
                Blue = (Foreground)8,
                Cyan = (Foreground)408,
                Magenta = (Foreground)409,
                Yellow = (Foreground)410;
        }

        public static class Basic
        {
            public const Foreground
                Gray = (Foreground)9,
                Blue = (Foreground)10,
                Purple = (Foreground)11,
                Red = (Foreground)12,
                Yellow = (Foreground)13,
                Green = (Foreground)14,
                Cyan = (Foreground)15,
                Black = (Foreground)182;
        }

        public static class Brick
        {
            public const Foreground
                Orange = (Foreground)16,
                Teal = (Foreground)17,
                Purple = (Foreground)18,
                Green = (Foreground)19,
                Red = (Foreground)20,
                Tan = (Foreground)21;
        }

        public static class Special
        {
            public const Foreground
                Striped = (Foreground)22,
                Face = (Foreground)32,
                GlossyBlack = (Foreground)33,
                FullyBlack = (Foreground)44;
        }


        public static class Door
        {
            public const Foreground
                Red = (Foreground)23,
                Green = (Foreground)24,
                Blue = (Foreground)25,
                Cyan = (Foreground)1005, // TODO Ids
                Magenta = (Foreground)1006,
                Yellow = (Foreground)1007,

                Coin = (Foreground)43,
                BlueCoin = (Foreground)213,
                Purple = (Foreground)184,
                Death = (Foreground)1011,


                Timed = (Foreground)156,
                BuildersClub = (Foreground)200,
                Zombie = (Foreground)207;
        }


        public static class Gate
        {
            public const Foreground
                Red = (Foreground)26,
                Green = (Foreground)27,
                Blue = (Foreground)28,
                Cyan = (Foreground)1008,
                Magenta = (Foreground)1009,
                Yellow = (Foreground)1010,

                Coin = (Foreground)165,
                BlueCoin = (Foreground)214,
                Purple = (Foreground)185,
                Death = (Foreground)1012,

                Timed = (Foreground)157,
                BuildersClub = (Foreground)201,
                Zombie = (Foreground)206;
        }

        public static class Metal
        {
            public const Foreground
                White = (Foreground)29,
                Red = (Foreground)30,
                Yellow = (Foreground)31;
        }

        public static class Grass
        {
            public const Foreground
                Left = (Foreground)34,
                Middle = (Foreground)35,
                Right = (Foreground)36;
        }

        public static class Beta
        {
            public const Foreground
                Pink = (Foreground)37,
                Green = (Foreground)38,
                Blue = (Foreground)39,
                Red = (Foreground)40,
                Yellow = (Foreground)41,
                Gray = (Foreground)42;
        }

        public static class Factory
        {
            public const Foreground
                TanCross = (Foreground)45,
                Planks = (Foreground)46,
                Sandpaper = (Foreground)47,
                BrownCross = (Foreground)48,
                Fishscales = (Foreground)49;
        }

        public static class Secret
        {
            public const Foreground
                Unpassable = (Foreground)50,
                InvisibleUnpassable = (Foreground)136,
                Passable = (Foreground)243;
        }

        public static class Glass
        {
            public const Foreground
                Red = (Foreground)51,
                Pink = (Foreground)52,
                Indigo = (Foreground)53,
                Blue = (Foreground)54,
                Cyan = (Foreground)55,
                Green = (Foreground)56,
                Yellow = (Foreground)57,
                Orange = (Foreground)58;
        }

        public static class Summer2011
        {
            public const Foreground
                Sand = (Foreground)59,
                Sunshade = (Foreground)228,
                RightCornerSand = (Foreground)229,
                LeftCornerSand = (Foreground)230,
                Rock = (Foreground)231;
        }

        public static class Candy
        {
            public const Foreground
                Pink = (Foreground)60,
                OneWayPink = (Foreground)61,
                OneWayRed = (Foreground)62,
                OneWayCyan = (Foreground)63,
                OneWayGreen = (Foreground)64,
                CandyCane = (Foreground)65,
                CandyCorn = (Foreground)66,
                Chocolate = (Foreground)67,
                Topping = (Foreground)227;
        }

        public static class Halloween2011
        {
            public const Foreground
                Blood = (Foreground)68,
                FullBrick = (Foreground)69,
                Tombstone = (Foreground)224,
                LeftCornerWeb = (Foreground)225,
                RightCornerWeb = (Foreground)226;
        }

        public static class Mineral
        {
            public const Foreground
                Red = (Foreground)70,
                Pink = (Foreground)71,
                Blue = (Foreground)72,
                Cyan = (Foreground)73,
                Green = (Foreground)74,
                Yellow = (Foreground)75,
                Orange = (Foreground)76;
        }

        public static class Music
        {

            public const Foreground
                Piano = (Foreground)77,
                Drum = (Foreground)83;
        }

        public static class Christmas2011
        {
            public const Foreground
                YellowBox = (Foreground)78,
                WhiteBox = (Foreground)79,
                RedBox = (Foreground)80,
                BlueBox = (Foreground)81,
                GreenBox = (Foreground)82,
                SphereBlue = (Foreground)218,
                SphereGreen = (Foreground)219,
                SphereRed = (Foreground)220,
                Wreath = (Foreground)221,
                Star = (Foreground)222;
        }

        public static class SciFi
        {
            public const Foreground
                Red = (Foreground)84,
                Blue = (Foreground)85,
                Gray = (Foreground)86,
                White = (Foreground)87,
                Brown = (Foreground)88,
                OneWayRed = (Foreground)89,
                OneWayBlue = (Foreground)90,
                OneWayGreen = (Foreground)91;
        }

        public static class Prison
        {
            public const Foreground
                Wall = (Foreground)92,
                Bars = (Foreground)261;
        }

        public static class Pirate
        {
            public const Foreground
                Planks = (Foreground)93,
                Chest = (Foreground)94,
                Canoncover = (Foreground)271,
                Skull = (Foreground)272;

        }

        public static class Viking
        {
            public const Foreground
                Gray = (Foreground)95,
                RedShield = (Foreground)273,
                BlueShield = (Foreground)274,
                Axe = (Foreground)275;

        }

        public static class Ninja
        {
            public const Foreground
                White = (Foreground)96,
                Gray = (Foreground)97,
                Ladder = (Foreground)120,
                LeftBrightRoofTop = (Foreground)276,
                RightBrightRoofTop = (Foreground)277,
                BrightWindow = (Foreground)278,
                LeftDarkRoofTop = (Foreground)279,
                RightDarkRoofTop = (Foreground)280,
                DarkWindow = (Foreground)281,
                LadderShape = (Foreground)282,
                AntennaShape = (Foreground)283,
                YinYang = (Foreground)284;
        }

        public static class Coin
        {
            public const Foreground
                Gold = (Foreground)100,
                Blue = (Foreground)101;
        }

        public static class Switch
        {
            public const Foreground
                Purple = (Foreground)113;
        }

        public static class Boost
        {
            public const Foreground
                Left = (Foreground)114,
                Right = (Foreground)115,
                Up = (Foreground)116,
                Down = (Foreground)117;
        }

        public static class Water
        {
            public const Foreground
                Liquid = (Foreground)119,
                Waves = (Foreground)300;

        }

        public static class Tool
        {
            public const Foreground
                Trophy = (Foreground)121,
                SpawnPoint = (Foreground)255,
                Checkpoint = (Foreground)360;

        }

        public static class Cowboy
        {
            public const Foreground
                BrownLit = (Foreground)122,
                RedLit = (Foreground)123,
                BlueLit = (Foreground)124,
                BrownDark = (Foreground)125,
                RedDark = (Foreground)126,
                BlueDark = (Foreground)127,
                PoleLit = (Foreground)285,
                PoleDark = (Foreground)286,
                DoorBrownLeft = (Foreground)287,
                DoorBrownRight = (Foreground)288,
                DoorRedLeft = (Foreground)289,
                DoorRedRight = (Foreground)290,
                DoorBlueLeft = (Foreground)291,
                DoorBlueRight = (Foreground)292,
                Window = (Foreground)293,
                TableBrownLit = (Foreground)294,
                TableBrownDark = (Foreground)295,
                TableRedLit = (Foreground)296,
                TableRedDark = (Foreground)297,
                TableBlueLit = (Foreground)298,
                TableBlueDark = (Foreground)299;

        }

        public static class Plastic
        {
            public const Foreground
                LightGreen = (Foreground)128,
                Red = (Foreground)129,
                Yellow = (Foreground)130,
                Cyan = (Foreground)131,
                Blue = (Foreground)132,
                Pink = (Foreground)133,
                Green = (Foreground)134,
                Orange = (Foreground)135;

        }

        public static class Sand
        {
            public const Foreground
                White = (Foreground)137,
                Gray = (Foreground)138,
                Yellow = (Foreground)139,
                Orange = (Foreground)140,
                Tan = (Foreground)141,
                Brown = (Foreground)142,
                DuneWhite = (Foreground)301,
                DuneGray = (Foreground)302,
                DuneYellow = (Foreground)303,
                DuneOrange = (Foreground)304,
                DuneTan = (Foreground)305,
                DuneBrown = (Foreground)306;

        }

        public static class Cloud
        {
            public const Foreground
                White = (Foreground)143,
                Bottom = (Foreground)311,
                Top = (Foreground)312,
                Right = (Foreground)313,
                Left = (Foreground)314,
                BottomLeftCorner = (Foreground)315,
                BottomRightCorner = (Foreground)316,
                TopRightCorner = (Foreground)317,
                TopLeftCorner = (Foreground)318;
        }

        public static class PlateIron
        {
            public const Foreground
                Iron = (Foreground)144,
                Wires = (Foreground)145;

        }

        public static class Industrial
        {
            public const Foreground
                OneWay = (Foreground)146,
                CrossSupport = (Foreground)147,
                Elevator = (Foreground)148,
                Support = (Foreground)149,
                LeftConveyor = (Foreground)150,
                SupportedMiddleConveyor = (Foreground)151,
                MiddleConveyor = (Foreground)152,
                RightConveyor = (Foreground)153;

        }

        public static class Timbered
        {
            public const Foreground
                OneWay = (Foreground)154;

        }

        public static class Castle
        {
            public const Foreground
                Ladder = (Foreground)118,
                CastleOneWay = (Foreground)158,
                CastleWall = (Foreground)159,
                CastleWindow = (Foreground)160,
                Castle1 = (Foreground)325,
                Castle2 = (Foreground)326;

        }

        public static class Medieval
        {
            public const Foreground
                Anvil = (Foreground)162,
                Barrel = (Foreground)163,
                BlueBanner = (Foreground)327,
                RedBanner = (Foreground)328,
                Sword = (Foreground)329,
                Shield = (Foreground)330,
                Rock = (Foreground)331;

        }

        public static class Pipe
        {
            public const Foreground
                Left = (Foreground)166,
                Horizontal = (Foreground)167,
                Right = (Foreground)168,
                Up = (Foreground)169,
                Vertical = (Foreground)170,
                Down = (Foreground)171;
        }

        public static class Rocket
        {
            public const Foreground
                White = (Foreground)172,
                Blue = (Foreground)173,
                Green = (Foreground)174,
                Red = (Foreground)175,
                GreenSign = (Foreground)332,
                RedLight = (Foreground)333,
                BlueLight = (Foreground)334,
                Computer = (Foreground)335;
        }

        public static class Mars
        {
            public const Foreground
                Sand = (Foreground)176,
                Pattern1 = (Foreground)177,
                Pattern2 = (Foreground)178,
                Pattern3 = (Foreground)179,
                Rock1 = (Foreground)180,
                Rock2 = (Foreground)181,
                Rock = (Foreground)336;

        }

        public static class Checker
        {
            public const Foreground
                Gray = (Foreground)186,
                DarkBlue = (Foreground)187,
                Purple = (Foreground)188,
                Red = (Foreground)189,
                Yellow = (Foreground)190,
                Green = (Foreground)191,
                LightBlue = (Foreground)192;
        }

        public static class Jungle
        {
            public const Foreground
                LadderVertical = (Foreground)98,
                LadderHorizontal = (Foreground)99,
                Vase = (Foreground)199,
                Undergrowth = (Foreground)357,
                Log = (Foreground)358,
                Idol = (Foreground)359;
        }

        public static class JungleRuins
        {
            public const Foreground
                RoundedEdgeFace = (Foreground)193,
                OneWay = (Foreground)194,
                NonRoundedGray = (Foreground)195,
                Red = (Foreground)196,
                Blue = (Foreground)197,
                Yellow = (Foreground)198;
        }

        public static class Lava
        {
            public const Foreground
                Yellow = (Foreground)202,
                Orange = (Foreground)203,
                Red = (Foreground)204;
        }

        public static class Sparta
        {
            public const Foreground
                Gray = (Foreground)208,
                Green = (Foreground)209,
                Red = (Foreground)210,
                OneWay = (Foreground)211,
                PillarTop = (Foreground)382,
                PillarMiddle = (Foreground)383,
                PillarBottom = (Foreground)384;

        }

        public static class Farm
        {
            public const Foreground
                Hay = (Foreground)212,
                Crop = (Foreground)386,
                Plants = (Foreground)387,
                FenceLeftEnded = (Foreground)388,
                FenceRightEnded = (Foreground)389;

        }

        public static class Autumn2014
        {
            public const Foreground
                RightCornerLeaves = (Foreground)390,
                LeftCornerLeaves = (Foreground)391,
                LeftGrass = (Foreground)392,
                MiddleGrass = (Foreground)393,
                RightGrass = (Foreground)394,
                Acorn = (Foreground)395,
                Pumpkin = (Foreground)396;
        }

        public static class Christmas2014
        {
            public const Foreground
                Ice = (Foreground)215,
                OneWay = (Foreground)216,
                LeftSnow = (Foreground)398,
                MiddleSnow = (Foreground)399,
                RightSnow = (Foreground)400,
                CandyCane = (Foreground)401,
                Wreath = (Foreground)402,
                Stocking = (Foreground)403,
                Bow = (Foreground)404;
        }

        public static class Hologram
        {
            public const Foreground
                Block = (Foreground)397;
        }

        public static class Prize
        {
            public const Foreground
                Trophy = (Foreground)223;
        }

        public static class Spring2011
        {
            public const Foreground
                LeftGrass = (Foreground)233,
                MiddleGrass = (Foreground)234,
                RightGrass = (Foreground)235,
                LeftBush = (Foreground)236,
                MiddleBush = (Foreground)237,
                RightBush = (Foreground)238,
                Flower = (Foreground)239,
                Shrub = (Foreground)240;
        }

        public static class Diamond
        {
            public const Foreground
                Block = (Foreground)241;
        }

        public static class Portal
        {
            public const Foreground
                Normal = (Foreground)242,
                World = (Foreground)374,
                Invisible = (Foreground)381;
        }

        public static class NewYear2010
        {
            public const Foreground
                Purple = (Foreground)244,
                Yellow = (Foreground)245,
                Blue = (Foreground)246,
                Red = (Foreground)247,
                Green = (Foreground)248;

        }

        public static class Christmas2010
        {
            public const Foreground
                RightCornerSnow = (Foreground)249,
                LeftCornerSnow = (Foreground)250,
                Tree = (Foreground)251,
                SnowyTree = (Foreground)252,
                SnowyFence = (Foreground)253,
                Fence = (Foreground)254;
        }

        public static class Easter2012
        {
            public const Foreground
                BlueEgg = (Foreground)256,
                PinkEgg = (Foreground)257,
                YellowEgg = (Foreground)258,
                RedEgg = (Foreground)259,
                GreenEgg = (Foreground)260;
        }

        public static class Window
        {
            public const Foreground
                Clear = (Foreground)262,
                Green = (Foreground)263,
                Teal = (Foreground)264,
                Blue = (Foreground)265,
                Purple = (Foreground)266,
                Pink = (Foreground)267,
                Red = (Foreground)268,
                Orange = (Foreground)269,
                Yellow = (Foreground)270;
        }

        public static class Summer2012
        {
            public const Foreground
                Ball = (Foreground)307,
                Bucket = (Foreground)308,
                Grubber = (Foreground)309,
                Cocktail = (Foreground)310;
        }

        public static class WarningSign
        {
            public const Foreground
                Fire = (Foreground)319,
                Skull = (Foreground)320,
                Lightning = (Foreground)321,
                Cross = (Foreground)322,
                HorizontalLine = (Foreground)323,
                VerticalLine = (Foreground)324;
        }

        public static class Cake
        {
            public const Foreground
                Block = (Foreground)337;
        }

        public static class Monster
        {
            public const Foreground
                BigToothBottom = (Foreground)338,
                SmallTeethBottom = (Foreground)339,
                SmallTeethTop = (Foreground)340,
                OrangeEye = (Foreground)341,
                BlueEye = (Foreground)342;
        }

        public static class Fog
        {
            public const Foreground
                Full = (Foreground)343,
                Bottom = (Foreground)344,
                Top = (Foreground)345,
                Right = (Foreground)346,
                Left = (Foreground)347,
                BottomLeftCorner = (Foreground)348,
                BottomRightCorner = (Foreground)349,
                TopRightCorner = (Foreground)350,
                TopLeftCorner = (Foreground)351;
        }

        public static class Halloween2012
        {
            public const Foreground
                TeslaCap = (Foreground)352,
                TeslaCoil= (Foreground)353,
                WiresVertical = (Foreground)354,
                WiresHorizontal = (Foreground)355,
                Electricity = (Foreground)356;
        }
        
        public static class Hazard
        {
            public const Foreground
                Spike = (Foreground)361,
                Fire = (Foreground)368;

        }

        public static class Swamp
        {
            public const Foreground
                Liquid = (Foreground)369,
                MudBubbles = (Foreground)370,
                Grass = (Foreground)371,
                Log = (Foreground)372,
                Radioactive = (Foreground)373;

        }

        public static class Christmas2012
        {
            public const Foreground
                BlueVertical = (Foreground)362,
                BlueHorizontal = (Foreground)363,
                BlueCross = (Foreground)364,
                RedVertical = (Foreground)365,
                RedHorizontal = (Foreground)366,
                RedCross = (Foreground)367;
        }

        public static class SciFi2013
        {
            public const Foreground
                BlueSlope = (Foreground)375,
                BlueStraight = (Foreground)376,
                YellowSlope = (Foreground)377,
                YellowStraight = (Foreground)378,
                GreenSlope = (Foreground)379,
                GreenStraight = (Foreground)380;
        }

        public static class Sign
        {
            public const Foreground
                Block = (Foreground)385;
        }
       
        public static class Admin
        {
            public const Foreground
                Text = (Foreground)1000;
        }

        public static class OneWay
        {
            public const Foreground
                Cyan = (Foreground)1001,
                Red = (Foreground)1002,
                Yellow = (Foreground)1003,
                Pink = (Foreground)1004;
        }

        public static class Valentines2015
        {
            public const Foreground
                RedHeart = (Foreground)405,
                PurpleHeart = (Foreground)406,
                PinkHeart = (Foreground)407;
        }
    }
}