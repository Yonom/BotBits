// ReSharper disable MemberHidesStaticFromOuterClass
namespace BotBits
{
    public static class Foreground
    {
        public enum Id : ushort
        {
        }

        public const Id
            Empty = Gravity.Down;

        public static class Gravity
        {
            public const Id
                Down = 0,
                Left = (Id)1,
                Up = (Id)2,
                Right = (Id)3,
                Dot = (Id)4,
                InvisibleLeft = (Id)411,
                InvisibleUp = (Id)412,
                InvisibleRight = (Id)413,
                InvisibleDot = (Id)414;
        }

        public static class Crown
        {
            public const Id
                Gold = (Id)5;
        }

        public static class Key
        {
            public const Id
                Red = (Id)6,
                Green = (Id)7,
                Blue = (Id)8,
                Cyan = (Id)408,
                Magenta = (Id)409,
                Yellow = (Id)410;
        }

        public static class Basic
        {
            public const Id
                Gray = (Id)9,
                Blue = (Id)10,
                Purple = (Id)11,
                Red = (Id)12,
                Orange = (Id)1018,
                Yellow = (Id)13,
                Green = (Id)14,
                Cyan = (Id)15,
                Black = (Id)182;
        }

        public static class Brick
        {
            public const Id
                Gray = (Id)1022,
                Orange = (Id)16,
                Blue = (Id)1023,
                Teal = (Id)17,
                Purple = (Id)18,
                Green = (Id)19,
                Red = (Id)20,
                Tan = (Id)21,
                Black = (Id)1024;
        }

        public static class Special
        {
            public const Id
                Striped = (Id)22,
                Face = (Id)32,
                GlossyBlack = (Id)33,
                FullyBlack = (Id)44;
        }


        public static class Door
        {
            public const Id
                Red = (Id)23,
                Green = (Id)24,
                Blue = (Id)25,
                Cyan = (Id)1005, 
                Magenta = (Id)1006,
                Yellow = (Id)1007,

                Coin = (Id)43,
                BlueCoin = (Id)213,
                Purple = (Id)184,
                Death = (Id)1011,


                Timed = (Id)156,
                BuildersClub = (Id)200,
                Zombie = (Id)207;
        }


        public static class Gate
        {
            public const Id
                Red = (Id)26,
                Green = (Id)27,
                Blue = (Id)28,
                Cyan = (Id)1008,
                Magenta = (Id)1009,
                Yellow = (Id)1010,

                Coin = (Id)165,
                BlueCoin = (Id)214,
                Purple = (Id)185,
                Death = (Id)1012,

                Timed = (Id)157,
                BuildersClub = (Id)201,
                Zombie = (Id)206;
        }

        public static class Metal
        {
            public const Id
                White = (Id)29,
                Red = (Id)30,
                Yellow = (Id)31;
        }

        public static class Grass
        {
            public const Id
                Left = (Id)34,
                Middle = (Id)35,
                Right = (Id)36;
        }

        public static class Beta
        {
            public const Id
                Pink = (Id)37,
                Green = (Id)38,
                Cyan = (Id)1019,
                Blue = (Id)39,
                Red = (Id)40,
                Orange = (Id)1020,
                Yellow = (Id)41,
                Gray = (Id)42,
                Black = (Id)1021;
        }

        public static class Factory
        {
            public const Id
                TanCross = (Id)45,
                Planks = (Id)46,
                Sandpaper = (Id)47,
                BrownCross = (Id)48,
                Fishscales = (Id)49;
        }

        public static class Secret
        {
            public const Id
                Unpassable = (Id)50,
                InvisibleUnpassable = (Id)136,
                Passable = (Id)243;
        }

        public static class Glass
        {
            public const Id
                Red = (Id)51,
                Pink = (Id)52,
                Indigo = (Id)53,
                Blue = (Id)54,
                Cyan = (Id)55,
                Green = (Id)56,
                Yellow = (Id)57,
                Orange = (Id)58;
        }

        public static class Summer2011
        {
            public const Id
                Sand = (Id)59,
                Sunshade = (Id)228,
                RightCornerSand = (Id)229,
                LeftCornerSand = (Id)230,
                Rock = (Id)231;
        }

        public static class Candy
        {
            public const Id
                Pink = (Id)60,
                OneWayPink = (Id)61,
                OneWayRed = (Id)62,
                OneWayCyan = (Id)63,
                OneWayGreen = (Id)64,
                CandyCane = (Id)65,
                CandyCorn = (Id)66,
                Chocolate = (Id)67,
                Topping = (Id)227;
        }

        public static class Halloween2011
        {
            public const Id
                Blood = (Id)68,
                FullBrick = (Id)69,
                Tombstone = (Id)224,
                LeftCornerWeb = (Id)225,
                RightCornerWeb = (Id)226;
        }

        public static class Mineral
        {
            public const Id
                Red = (Id)70,
                Pink = (Id)71,
                Blue = (Id)72,
                Cyan = (Id)73,
                Green = (Id)74,
                Yellow = (Id)75,
                Orange = (Id)76;
        }

        public static class Music
        {

            public const Id
                Piano = (Id)77,
                Drum = (Id)83;
        }

        public static class Christmas2011
        {
            public const Id
                YellowBox = (Id)78,
                WhiteBox = (Id)79,
                RedBox = (Id)80,
                BlueBox = (Id)81,
                GreenBox = (Id)82,
                SphereBlue = (Id)218,
                SphereGreen = (Id)219,
                SphereRed = (Id)220,
                Wreath = (Id)221,
                Star = (Id)222;
        }

        public static class SciFi
        {
            public const Id
                Red = (Id)84,
                Blue = (Id)85,
                Gray = (Id)86,
                White = (Id)87,
                Brown = (Id)88,
                OneWayRed = (Id)89,
                OneWayBlue = (Id)90,
                OneWayGreen = (Id)91;
        }

        public static class Prison
        {
            public const Id
                Wall = (Id)92,
                Bars = (Id)261;
        }

        public static class Pirate
        {
            public const Id
                Planks = (Id)93,
                Chest = (Id)94,
                Canoncover = (Id)271,
                Skull = (Id)272;

        }

        public static class Viking
        {
            public const Id
                Gray = (Id)95,
                RedShield = (Id)273,
                BlueShield = (Id)274,
                Axe = (Id)275;

        }

        public static class Ninja
        {
            public const Id
                White = (Id)96,
                Gray = (Id)97,
                Ladder = (Id)120,
                LeftBrightRoofTop = (Id)276,
                RightBrightRoofTop = (Id)277,
                BrightWindow = (Id)278,
                LeftDarkRoofTop = (Id)279,
                RightDarkRoofTop = (Id)280,
                DarkWindow = (Id)281,
                LadderShape = (Id)282,
                AntennaShape = (Id)283,
                YinYang = (Id)284;
        }

        public static class Coin
        {
            public const Id
                Gold = (Id)100,
                Blue = (Id)101;
        }

        public static class Switch
        {
            public const Id
                Purple = (Id)113;
        }

        public static class Boost
        {
            public const Id
                Left = (Id)114,
                Right = (Id)115,
                Up = (Id)116,
                Down = (Id)117;
        }

        public static class Water
        {
            public const Id
                Liquid = (Id)119,
                Waves = (Id)300;

        }

        public static class Tool
        {
            public const Id
                Trophy = (Id)121,
                SpawnPoint = (Id)255,
                Checkpoint = (Id)360;

        }

        public static class Cowboy
        {
            public const Id
                BrownLit = (Id)122,
                RedLit = (Id)123,
                BlueLit = (Id)124,
                BrownDark = (Id)125,
                RedDark = (Id)126,
                BlueDark = (Id)127,
                PoleLit = (Id)285,
                PoleDark = (Id)286,
                DoorBrownLeft = (Id)287,
                DoorBrownRight = (Id)288,
                DoorRedLeft = (Id)289,
                DoorRedRight = (Id)290,
                DoorBlueLeft = (Id)291,
                DoorBlueRight = (Id)292,
                Window = (Id)293,
                TableBrownLit = (Id)294,
                TableBrownDark = (Id)295,
                TableRedLit = (Id)296,
                TableRedDark = (Id)297,
                TableBlueLit = (Id)298,
                TableBlueDark = (Id)299;

        }

        public static class Plastic
        {
            public const Id
                LightGreen = (Id)128,
                Red = (Id)129,
                Yellow = (Id)130,
                Cyan = (Id)131,
                Blue = (Id)132,
                Pink = (Id)133,
                Green = (Id)134,
                Orange = (Id)135;

        }

        public static class Sand
        {
            public const Id
                White = (Id)137,
                Gray = (Id)138,
                Yellow = (Id)139,
                Orange = (Id)140,
                Tan = (Id)141,
                Brown = (Id)142,
                DuneWhite = (Id)301,
                DuneGray = (Id)302,
                DuneYellow = (Id)303,
                DuneOrange = (Id)304,
                DuneTan = (Id)305,
                DuneBrown = (Id)306;

        }

        public static class Cloud
        {
            public const Id
                White = (Id)143,
                Bottom = (Id)311,
                Top = (Id)312,
                Right = (Id)313,
                Left = (Id)314,
                BottomLeftCorner = (Id)315,
                BottomRightCorner = (Id)316,
                TopRightCorner = (Id)317,
                TopLeftCorner = (Id)318;
        }

        public static class PlateIron
        {
            public const Id
                Iron = (Id)144,
                Wires = (Id)145;

        }

        public static class Industrial
        {
            public const Id
                OneWay = (Id)146,
                CrossSupport = (Id)147,
                Elevator = (Id)148,
                Support = (Id)149,
                LeftConveyor = (Id)150,
                SupportedMiddleConveyor = (Id)151,
                MiddleConveyor = (Id)152,
                RightConveyor = (Id)153;

        }

        public static class Timbered
        {
            public const Id
                OneWay = (Id)154;

        }

        public static class Castle
        {
            public const Id
                Ladder = (Id)118,
                CastleOneWay = (Id)158,
                CastleWall = (Id)159,
                CastleWindow = (Id)160,
                Castle1 = (Id)325,
                Castle2 = (Id)326;

        }

        public static class Medieval
        {
            public const Id
                Anvil = (Id)162,
                Barrel = (Id)163,
                BlueBanner = (Id)327,
                RedBanner = (Id)328,
                Sword = (Id)329,
                Shield = (Id)330,
                Rock = (Id)331;

        }

        public static class Pipe
        {
            public const Id
                Left = (Id)166,
                Horizontal = (Id)167,
                Right = (Id)168,
                Up = (Id)169,
                Vertical = (Id)170,
                Down = (Id)171;
        }

        public static class Rocket
        {
            public const Id
                White = (Id)172,
                Blue = (Id)173,
                Green = (Id)174,
                Red = (Id)175,
                GreenSign = (Id)332,
                RedLight = (Id)333,
                BlueLight = (Id)334,
                Computer = (Id)335;
        }

        public static class Mars
        {
            public const Id
                Sand = (Id)176,
                Pattern1 = (Id)177,
                Pattern2 = (Id)178,
                Pattern3 = (Id)179,
                Rock1 = (Id)180,
                Rock2 = (Id)181,
                Rock = (Id)336;

        }

        public static class Checker
        {
            public const Id
                Gray = (Id)186,
                DarkBlue = (Id)187,
                Purple = (Id)188,
                Red = (Id)189,
                Yellow = (Id)190,
                Green = (Id)191,
                LightBlue = (Id)192,
                Orange = (Id)1025,
                Black = (Id)1026;
        }

        public static class Jungle
        {
            public const Id
                LadderVertical = (Id)98,
                LadderHorizontal = (Id)99,
                Vase = (Id)199,
                Undergrowth = (Id)357,
                Log = (Id)358,
                Idol = (Id)359;
        }

        public static class JungleRuins
        {
            public const Id
                RoundedEdgeFace = (Id)193,
                OneWay = (Id)194,
                NonRoundedGray = (Id)195,
                Red = (Id)196,
                Blue = (Id)197,
                Yellow = (Id)198;
        }

        public static class Lava
        {
            public const Id
                Yellow = (Id)202,
                Orange = (Id)203,
                Red = (Id)204;
        }

        public static class Sparta
        {
            public const Id
                Gray = (Id)208,
                Green = (Id)209,
                Red = (Id)210,
                OneWay = (Id)211,
                PillarTop = (Id)382,
                PillarMiddle = (Id)383,
                PillarBottom = (Id)384;

        }

        public static class Farm
        {
            public const Id
                Hay = (Id)212,
                Crop = (Id)386,
                Plants = (Id)387,
                FenceLeftEnded = (Id)388,
                FenceRightEnded = (Id)389;

        }

        public static class Autumn2014
        {
            public const Id
                RightCornerLeaves = (Id)390,
                LeftCornerLeaves = (Id)391,
                LeftGrass = (Id)392,
                MiddleGrass = (Id)393,
                RightGrass = (Id)394,
                Acorn = (Id)395,
                Pumpkin = (Id)396;
        }

        public static class Christmas2014
        {
            public const Id
                Ice = (Id)215,
                OneWay = (Id)216,
                LeftSnow = (Id)398,
                MiddleSnow = (Id)399,
                RightSnow = (Id)400,
                CandyCane = (Id)401,
                Wreath = (Id)402,
                Stocking = (Id)403,
                Bow = (Id)404;
        }

        public static class Hologram
        {
            public const Id
                Block = (Id)397;
        }

        public static class Prize
        {
            public const Id
                Trophy = (Id)223;
        }

        public static class Spring2011
        {
            public const Id
                LeftGrass = (Id)233,
                MiddleGrass = (Id)234,
                RightGrass = (Id)235,
                LeftBush = (Id)236,
                MiddleBush = (Id)237,
                RightBush = (Id)238,
                Flower = (Id)239,
                Shrub = (Id)240;
        }

        public static class Diamond
        {
            public const Id
                Block = (Id)241;
        }

        public static class Portal
        {
            public const Id
                Normal = (Id)242,
                World = (Id)374,
                Invisible = (Id)381;
        }

        public static class NewYear2010
        {
            public const Id
                Purple = (Id)244,
                Yellow = (Id)245,
                Blue = (Id)246,
                Red = (Id)247,
                Green = (Id)248;

        }

        public static class Christmas2010
        {
            public const Id
                RightCornerSnow = (Id)249,
                LeftCornerSnow = (Id)250,
                Tree = (Id)251,
                DecoratedTree = (Id)252,
                SnowyFence = (Id)253,
                Fence = (Id)254;
        }

        public static class Easter2012
        {
            public const Id
                BlueEgg = (Id)256,
                PinkEgg = (Id)257,
                YellowEgg = (Id)258,
                RedEgg = (Id)259,
                GreenEgg = (Id)260;
        }

        public static class Window
        {
            public const Id
                Clear = (Id)262,
                Green = (Id)263,
                Teal = (Id)264,
                Blue = (Id)265,
                Purple = (Id)266,
                Pink = (Id)267,
                Red = (Id)268,
                Orange = (Id)269,
                Yellow = (Id)270;
        }

        public static class Summer2012
        {
            public const Id
                Ball = (Id)307,
                Bucket = (Id)308,
                Grubber = (Id)309,
                Cocktail = (Id)310;
        }

        public static class WarningSign
        {
            public const Id
                Fire = (Id)319,
                Skull = (Id)320,
                Lightning = (Id)321,
                Cross = (Id)322,
                HorizontalLine = (Id)323,
                VerticalLine = (Id)324;
        }

        public static class Cake
        {
            public const Id
                Block = (Id)337;
        }

        public static class Monster
        {
            public const Id
                BigToothBottom = (Id)338,
                SmallTeethBottom = (Id)339,
                SmallTeethTop = (Id)340,
                OrangeEye = (Id)341,
                BlueEye = (Id)342;
        }

        public static class Fog
        {
            public const Id
                Full = (Id)343,
                Bottom = (Id)344,
                Top = (Id)345,
                Right = (Id)346,
                Left = (Id)347,
                BottomLeftCorner = (Id)348,
                BottomRightCorner = (Id)349,
                TopRightCorner = (Id)350,
                TopLeftCorner = (Id)351;
        }

        public static class Halloween2012
        {
            public const Id
                TeslaCap = (Id)352,
                TeslaCoil= (Id)353,
                WiresVertical = (Id)354,
                WiresHorizontal = (Id)355,
                Electricity = (Id)356;
        }
        
        public static class Hazard
        {
            public const Id
                Spike = (Id)361,
                Fire = (Id)368;

        }

        public static class Swamp
        {
            public const Id
                Liquid = (Id)369,
                MudBubbles = (Id)370,
                Grass = (Id)371,
                Log = (Id)372,
                Radioactive = (Id)373;

        }

        public static class Christmas2012
        {
            public const Id
                BlueVertical = (Id)362,
                BlueHorizontal = (Id)363,
                BlueCross = (Id)364,
                RedVertical = (Id)365,
                RedHorizontal = (Id)366,
                RedCross = (Id)367;
        }

        public static class SciFi2013
        {
            public const Id
                BlueSlope = (Id)375,
                BlueStraight = (Id)376,
                YellowSlope = (Id)377,
                YellowStraight = (Id)378,
                GreenSlope = (Id)379,
                GreenStraight = (Id)380;
        }

        public static class Sign
        {
            public const Id
                Block = (Id)385;
        }
       
        public static class Admin
        {
            public const Id
                Text = (Id)1000;
        }

        public static class OneWay
        {
            public const Id
                Cyan = (Id)1001,
                Red = (Id)1002,
                Yellow = (Id)1003,
                Pink = (Id)1004;
        }

        public static class Valentines2015
        {
            public const Id
                RedHeart = (Id)405,
                PurpleHeart = (Id)406,
                PinkHeart = (Id)407;
        }

        public static class Magic
        {
            public const Id
                Green = (Id)1013,
                Purple = (Id)1014,
                Orange = (Id)1015,
                Blue = (Id)1016,
                Red = (Id)1017;
        }
    }
}