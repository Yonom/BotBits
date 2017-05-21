using System.CodeDom;
using BotBits.Shop;

// ReSharper disable MemberHidesStaticFromOuterClass

namespace BotBits
{
    public static class Foreground
    {
        public enum Id : ushort
        {
        }

        public const Id
            Empty = 0;

        public static class Gravity
        {
            public const Id
                Left = (Id)1,
                Up = (Id)2,
                Right = (Id)3,
                Down = (Id)1518,
                Dot = (Id)4,
                InvisibleLeft = (Id)411,
                InvisibleUp = (Id)412,
                InvisibleRight = (Id)413,
                InvisibleDown = (Id)1519,
                InvisibleDot = (Id)414,
                SlowDot = (Id)459,
                InvisibleSlowDot = (Id)460;
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
                Black = (Id)182,
                White = (Id)1088;
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
                Black = (Id)1024,
                White = (Id)1090;
        }

        public static class Generic
        {
            public const Id
                StripedYellow = (Id)22,
                Yellow = (Id)1057,
                Face = (Id)32,
                Black = (Id)33,
                StripedBlack = (Id)1058;
        }


        public static class Door
        {
            public const Id
                Red = (Id)23,
                Green = (Id)24,
                Blue = (Id)25,
                Cyan = (Id)1005,
                Magenta = (Id)1006,
                Yellow = (Id)1007;
        }


        public static class Gate
        {
            public const Id
                Red = (Id)26,
                Green = (Id)27,
                Blue = (Id)28,
                Cyan = (Id)1008,
                Magenta = (Id)1009,
                Yellow = (Id)1010;
        }

        public static class Gold
        {
            [Pack("-", GoldMembershipItem = true)]
            public const Id
                Door = (Id)200,
                Gate = (Id)201,
                Basic = (Id)1065,
                Brick = (Id)1066,
                Panel = (Id)1067,
                Ornate = (Id)1068,
                OneWay = (Id)1069;
        }

        public static class Team
        {
            [Pack("brickeffectteam", ForegroundType = ForegroundType.Team)]
            public const Id
                Effect = (Id)423;

            [Pack("brickeffectteam", ForegroundType = ForegroundType.Team)]
            public const Id
                Door = (Id)1027;

            [Pack("brickeffectteam", ForegroundType = ForegroundType.Team)]
            public const Id
                Gate = (Id)1028;
        }

        public static class Death
        {
            [Pack("brickdeathdoor", ForegroundType = ForegroundType.Goal)]
            public const Id
                Door = (Id)1011;

            [Pack("brickdeathdoor", ForegroundType = ForegroundType.Goal)]
            public const Id
                Gate = (Id)1012;
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
            [Pack("pro")]
            public const Id
                Pink = (Id)37,
                Green = (Id)38,
                Cyan = (Id)1019,
                Blue = (Id)39,
                Red = (Id)40,
                Orange = (Id)1020,
                Yellow = (Id)41,
                Gray = (Id)42,
                Black = (Id)1021,
                White = (Id)1089;
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
                Passable = (Id)243,
                Black = (Id)44;
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
            [Pack("bricksummer2012")]
            public const Id
                Sand = (Id)59,
                Sunshade = (Id)228,
                RightCornerSand = (Id)229,
                LeftCornerSand = (Id)230,
                Rock = (Id)231;
        }

        public static class Candy
        {
            [Pack("brickcandy")]
            public const Id
                Pink = (Id)60,
                OneWayPink = (Id)61,
                OneWayRed = (Id)62,
                OneWayCyan = (Id)63,
                OneWayGreen = (Id)64,
                CandyCane = (Id)65,
                CandyCorn = (Id)66,
                Chocolate = (Id)67,
                ToppingSmall = (Id)227,
                ToppingBig = (Id)431,
                PuddingRed = (Id)432,
                PuddingGreen = (Id)433,
                PuddingPurple = (Id)434;
        }

        public static class Halloween2011
        {
            [Pack("brickhw2011")]
            public const Id
                Blood = (Id)68,
                FullBrick = (Id)69,
                Tombstone = (Id)224,
                LeftCornerWeb = (Id)225,
                RightCornerWeb = (Id)226;
        }

        public static class Mineral
        {
            [Pack("brickminiral")]
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
            [Pack("bricknode", ForegroundType = ForegroundType.Note)]
            public const Id
                Piano = (Id)77;

            [Pack("brickdrums", ForegroundType = ForegroundType.Note)]
            public const Id
                Drum = (Id)83;

            [Pack("brickguitar", ForegroundType = ForegroundType.Note)]
            public const Id
                Guitar = (Id)1520;
        }

        public static class Christmas2011
        {
            [Pack("brickxmas2011")]
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
            [Pack("brickscifi")]
            public const Id
                Red = (Id)84,
                Blue = (Id)85,
                Gray = (Id)86,
                White = (Id)87,
                Brown = (Id)88,
                OneWayRed = (Id)89,
                OneWayBlue = (Id)90,
                OneWayGreen = (Id)91,
                OneWayYellow = (Id)1051;

            [Pack("brickscifi", ForegroundType = ForegroundType.Morphable)]
            public const Id
                BlueSlope = (Id)375,
                BlueStraight = (Id)376,
                GreenSlope = (Id)379,
                GreenStraight = (Id)380,
                YellowSlope = (Id)377,
                YellowStraight = (Id)378,
                RedSlope = (Id)438,
                RedStraight = (Id)439;
        }

        public static class Prison
        {
            [Pack("brickprison")]
            public const Id
                Wall = (Id)92,
                Bars = (Id)261;
        }

        public static class Pirate
        {
            [Pack("brickpirate")]
            public const Id
                Planks = (Id)93,
                Chest = (Id)94,
                Canoncover = (Id)271,
                Skull = (Id)272,
                Canon = (Id)435,
                Window = (Id)436,
                OneWay = (Id)154;
        }

        public static class Stone
        {
            [Pack("brickstone")]
            public const Id
                Gray = (Id)95,
                Teal = (Id)1044,
                Brown = (Id)1045,
                Blue = (Id)1046;
        }

        public static class Dojo
        {
            [Pack("brickninja")]
            public const Id
                White = (Id)96,
                Gray = (Id)97,
                BrightWindow = (Id)278,
                DarkWindow = (Id)281,
                LadderShape = (Id)282,
                AntennaShape = (Id)283,
                YinYang = (Id)284;

            [Pack("brickninja", ForegroundType = ForegroundType.Morphable)]
            public const Id
                LeftRooftop = (Id)276,
                RightRooftop = (Id)277,
                LeftDarkRooftop = (Id)279,
                RightDarkRooftop = (Id)280;
        }

        public static class Ladder
        {
            [Pack("brickmedieval")]
            public const Id
                Chain = (Id)118;

            [Pack("brickninja")]
            public const Id
                Wood = (Id)120;

            public const Id
                VineVertical = (Id)98,
                VineHorizontal = (Id)99;

            [Pack("brickcowboy")]
            public const Id
                Rope = (Id)424;
        }

        public static class Coin
        {
            public const Id
                Gold = (Id)100,
                Blue = (Id)101;

            [Pack(ForegroundType = ForegroundType.Goal)]
            public const Id
                GoldDoor = (Id)43,
                GoldGate = (Id)165;

            [Pack(ForegroundType = ForegroundType.Goal)]
            public const Id
                BlueDoor = (Id)213,
                BlueGate = (Id)214;
        }

        public static class Switch
        {
            [Pack("brickswitchpurple", ForegroundType = ForegroundType.Goal)]
            public const Id
                Purple = (Id)113,
                PurpleDoor = (Id)184,
                PurpleGate = (Id)185;

            [Pack("brickswitchorange", ForegroundType = ForegroundType.Goal)]
            public const Id
                Orange = (Id)467,
                OrangeDoor = (Id)1079,
                OrangeGate = (Id)1080;
        }

        public static class Boost
        {
            [Pack("brickboost")]
            public const Id
                Left = (Id)114,
                Right = (Id)115,
                Up = (Id)116,
                Down = (Id)117;
        }

        public static class Water
        {
            public const Id
                Waves = (Id)300;
        }

        public static class Tool
        {
            public const Id
                Spawnpoint = (Id)255;

            public const Id
                Trophy = (Id)121;

            public const Id
                Checkpoint = (Id)360;

            public const Id
                Resetpoint = (Id)466;

            [Pack("brickgodblock")]
            public const Id
                GodBlock = (Id)1516;
        }

        public static class Crown
        {
            public const Id
                Block = (Id)5;

            [Pack("brickcrowndoor")]
            public const Id
                Door = (Id)1094,
                Gate = (Id)1095;
        }

        public static class WildWest
        {
            [Pack("brickcowboy")]
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
            [Pack("brickplastic")]
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
            [Pack("bricksand")]
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

        public static class Industrial
        {
            [Pack("brickindustrial")]
            public const Id
                Iron = (Id)144,
                Wires = (Id)145,
                OneWay = (Id)146,
                CrossSupport = (Id)147,
                Elevator = (Id)148,
                Support = (Id)149,
                LeftConveyor = (Id)150,
                SupportedMiddleConveyor = (Id)151,
                MiddleConveyor = (Id)152,
                RightConveyor = (Id)153,
                SignFire = (Id)319,
                SignSkull = (Id)320,
                SignLightning = (Id)321,
                SignCross = (Id)322,
                HorizontalLine = (Id)323,
                VerticalLine = (Id)324;
        }

        public static class Timed
        {
            [Pack("bricktimeddoor")]
            public const Id
                Door = (Id)156;

            [Pack("bricktimeddoor")]
            public const Id
                Gate = (Id)157;
        }

        public static class Medieval
        {
            [Pack("brickmedieval")]
            public const Id
                CastleOneWay = (Id)158,
                CastleWall = (Id)159,
                CastleWindow = (Id)160,
                Anvil = (Id)162,
                Barrel = (Id)163,
                CastleSupport = (Id)325,
                Tombstone = (Id)326,
                Shield = (Id)330,
                ClosedDoor = (Id)437;


            [Pack("brickmedieval", ForegroundType = ForegroundType.Morphable)]
            public const Id
                Timber = (Id)440,
                Axe = (Id)275,
                Sword = (Id)329,
                Circle = (Id)273,
                CoatOfArms = (Id)328,
                Banner = (Id)327;
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

        public static class OuterSpace
        {
            public const Id
                White = (Id)172,
                Blue = (Id)173,
                Green = (Id)174,
                Red = (Id)175,
                Dust = (Id)176,
                SilverTexture = (Id)1029,
                GreenSign = (Id)332,
                RedLight = (Id)333,
                BlueLight = (Id)334,
                Computer = (Id)335,
                BigStar = (Id)428,
                MediumStar = (Id)429,
                LittleStar = (Id)430,
                Stone = (Id)331;
        }

        public static class Desert
        {
            public const Id
                Pattern1 = (Id)177,
                Pattern2 = (Id)178,
                Pattern3 = (Id)179,
                Pattern4 = (Id)180,
                Pattern5 = (Id)181,
                Rock = (Id)336,
                Cactus = (Id)425,
                Shrub = (Id)426,
                Tree = (Id)427;
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
                Black = (Id)1026,
                White = (Id)1091;
        }

        public static class Jungle
        {
            public const Id
                Tiki = (Id)193,
                OneWay = (Id)194,
                Gray = (Id)195,
                Red = (Id)196,
                Blue = (Id)197,
                Yellow = (Id)198,
                Vase = (Id)199,
                Undergrowth = (Id)357,
                Log = (Id)358,
                Idol = (Id)359;
        }

        public static class Lava
        {
            [Pack("bricklava")]
            public const Id
                Yellow = (Id)202,
                Orange = (Id)203,
                Red = (Id)204,
                Waves = (Id)415;
        }

        public static class Marble
        {
            [Pack("bricksparta")]
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
            [Pack("brickfarm")]
            public const Id
                Hay = (Id)212,
                Crop = (Id)386,
                Plants = (Id)387,
                FenceLeftEnded = (Id)388,
                FenceRightEnded = (Id)389;
        }

        public static class Autumn2014
        {
            [Pack("brickautumn2014")]
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
            [Pack("brickchristmas2014")]
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

        public static class Zombie
        {
            [Pack("brickeffectzombie", ForegroundType = ForegroundType.ToggleGoal)]
            public const Id
                Effect = (Id)422;

            [Pack("brickzombiedoor")]
            public const Id
                Door = (Id)207;

            [Pack("brickzombiedoor")]
            public const Id
                Gate = (Id)206;
        }

        public static class Hologram
        {
            [Pack("brickhologram")]
            public const Id
                Block = (Id)397;
        }

        public static class Prize
        {
            [Pack("brickhwtrophy")]
            public const Id
                HalloweenTrophy = (Id)223;

            [Pack("brickspringtrophybronze")]
            public const Id
                BronzeSpringTrophy = (Id)478;

            [Pack("brickspringtrophysilver")]
            public const Id
                SilverSpringTrophy = (Id)479;

            [Pack("brickspringtrophygold")]
            public const Id
                GoldSpringTrophy = (Id)480;
        }

        public static class Spring2011
        {
            [Pack("brickspring2011")]
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
            [Pack("brickdiamond")]
            public const Id
                Block = (Id)241;
        }

        public static class Portal
        {
            [Pack("brickportal", ForegroundType = ForegroundType.Portal)]
            public const Id
                Normal = (Id)242;

            [Pack("brickinvisibleportal", ForegroundType = ForegroundType.Portal)]
            public const Id
                Invisible = (Id)381;

            [Pack("brickworldportal", ForegroundType = ForegroundType.WorldPortal)]
            public const Id
                World = (Id)374;
        }

        public static class NewYear2010
        {
            [Pack("mixednewyear2010")]
            public const Id
                Purple = (Id)244,
                Yellow = (Id)245,
                Blue = (Id)246,
                Red = (Id)247,
                Green = (Id)248;
        }

        public static class Christmas2010
        {
            [Pack("brickchristmas2010")]
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
            [Pack("brickeaster2012")]
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
            [Pack("bricksummer2012")]
            public const Id
                Ball = (Id)307,
                Bucket = (Id)308,
                Grubber = (Id)309,
                Cocktail = (Id)310;
        }

        public static class Cake
        {
            [Pack("brickcake")]
            public const Id
                Block = (Id)337;
        }

        public static class Monster
        {
            [Pack("brickmonster", ForegroundType = ForegroundType.Morphable)]
            public const Id
                BigTooth = (Id)338,
                SmallTooth = (Id)339,
                TripleTooth = (Id)340;

            [Pack("brickmonster")]
            public const Id
                PurpleEye = (Id)274,
                OrangeEye = (Id)341,
                BlueEye = (Id)342;
        }

        public static class Fog
        {
            [Pack("brickfog")]
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
            [Pack("brickhw2012")]
            public const Id
                TeslaCap = (Id)352,
                TeslaCoil = (Id)353,
                WiresVertical = (Id)354,
                WiresHorizontal = (Id)355,
                Electricity = (Id)356;
        }

        public static class Hazard
        {
            [Pack("brickspike", ForegroundType = ForegroundType.Morphable)]
            public const Id
                Spike = (Id)361;

            [Pack("brickfire")]
            public const Id
                Fire = (Id)368;
        }

        public static class Swamp
        {
            [Pack("brickswamp")]
            public const Id
                MudBubbles = (Id)370,
                Grass = (Id)371,
                Log = (Id)372,
                Radioactive = (Id)373;
        }

        public static class Christmas2012
        {
            [Pack("brickxmas2012")]
            public const Id
                BlueVertical = (Id)362,
                BlueHorizontal = (Id)363,
                BlueCross = (Id)364,
                RedVertical = (Id)365,
                RedHorizontal = (Id)366,
                RedCross = (Id)367;
        }

        public static class Sign
        {
            [Pack("bricksign", ForegroundType = ForegroundType.Sign)]
            public const Id
                Block = (Id)385;
        }

        public static class Admin
        {
            [Pack("-", AdminOnly = true, ForegroundType = ForegroundType.Label)]
            public const Id
                Text = (Id)1000;
        }

        public static class OneWay
        {
            [Pack("brickoneway", ForegroundType = ForegroundType.Morphable)]
            public const Id
                Cyan = (Id)1001,
                Orange = (Id)1002,
                Yellow = (Id)1003,
                Pink = (Id)1004,
                Gray = (Id)1052,
                Blue = (Id)1053,
                Red = (Id)1054,
                Green = (Id)1055,
                Black = (Id)1056,
                White = (Id)1092;
        }

        public static class Valentines2015
        {
            [Pack("brickvalentines2015")]
            public const Id
                RedHeart = (Id)405,
                PurpleHeart = (Id)406,
                PinkHeart = (Id)407;
        }

        public static class Magic
        {
            [Pack("brickmagic")]
            public const Id
                Green = (Id)1013;

            [Pack("brickmagic2")]
            public const Id
                Purple = (Id)1014;

            [Pack("brickmagic3")]
            public const Id
                Orange = (Id)1015;

            [Pack("brickmagic4")]
            public const Id
                Blue = (Id)1016;

            [Pack("brickmagic5")]
            public const Id
                Red = (Id)1017;
        }

        public static class Effect
        {
            [Pack("brickeffectjump", ForegroundType = ForegroundType.Toggle)]
            public const Id
                Jump = (Id)417;

            [Pack("brickeffectfly", ForegroundType = ForegroundType.Toggle)]
            public const Id
                Fly = (Id)418;

            [Pack("brickeffectspeed", ForegroundType = ForegroundType.Toggle)]
            public const Id
                Speed = (Id)419;

            [Pack("brickeffectprotection", ForegroundType = ForegroundType.Toggle)]
            public const Id
                Protection = (Id)420;

            [Pack("brickeffectcurse", ForegroundType = ForegroundType.ToggleGoal)]
            public const Id
                Curse = (Id)421;

            [Pack("brickeffectlowgravity", ForegroundType = ForegroundType.Toggle)]
            public const Id
                LowGravity = (Id)453;

            [Pack("brickeffectmultijump", ForegroundType = ForegroundType.Goal)]
            public const Id
                MultiJump = (Id)461;

            [Pack("brickeffectgravity", ForegroundType = ForegroundType.Morphable)]
            public const Id
                Gravity = (Id)1517; 
        }

        public static class Liquid
        {
            [Pack("brickswamp")]
            public const Id
                Swamp = (Id)369;

            public const Id
                Water = (Id)119;

            [Pack("bricklava")]
            public const Id
                Lava = (Id)416;
        }

        public static class Summer2015
        {
            [Pack("bricksummer2015")]
            public const Id
                Lifesaver = (Id)441,
                Anchor = (Id)442,
                RopeLeftEnded = (Id)443,
                RopeRightEnded = (Id)444,
                PalmTree = (Id)445;
        }

        public static class Environment
        {
            public const Id
                Tree = (Id)1030,
                Grass = (Id)1031,
                Bamboo = (Id)1032,
                Rock = (Id)1033,
                Lava = (Id)1034;
        }

        public static class Domestic
        {
            [Pack("brickdomestic")]
            public const Id
                Tile = (Id)1035,
                Wood = (Id)1036,
                CarpetRed = (Id)1037,
                CarpetBlue = (Id)1038,
                CarpetGreen = (Id)1039,
                WoodenPanel = (Id)1040,
                Lamp = (Id)446;

            [Pack("brickdomestic", ForegroundType = ForegroundType.Morphable)]
            public const Id
                HalfBlockBeige = (Id)1041,
                HalfBlockWood = (Id)1042,
                HalfBlockWhite = (Id)1043,
                LightBulb = (Id)447,
                Pipe = (Id)448,
                Painting = (Id)449,
                Vase = (Id)450,
                Television = (Id)451,
                Window = (Id)452;
        }

        public static class Halloween2015
        {
            [Pack("brickhalloween2015")]
            public const Id
                MossyBrick = (Id)1047,
                Siding = (Id)1048,
                Rooftop = (Id)1049,
                OneWay = (Id)1050,
                DeadShrub = (Id)454,
                IronFence = (Id)455;

            [Pack("brickhalloween2015", ForegroundType = ForegroundType.Morphable)]
            public const Id
                ArchedWindow = (Id)456,
                RoundWindow = (Id)457,
                Lantern = (Id)458;
        }

        public static class Ice
        {
            [Pack("brickice2")]
            public const Id
                Block = (Id)1064;
        }

        public static class Arctic
        {
            public const Id
                Ice = (Id)1059,
                Snow = (Id)1060,
                SnowyLeft = (Id)1061,
                SnowyMiddle = (Id)1062,
                SnowyRight = (Id)1063;
        }

        public static class NewYear2015
        {
            [Pack("bricknewyear2015")]
            public const Id
                WineGlass = (Id)462,
                Bottle = (Id)463;

            [Pack("bricknewyear2015", ForegroundType = ForegroundType.Morphable)]
            public const Id
                Balloon = (Id)464,
                Streamer = (Id)465;
        }

        public static class Fairytale
        {
            [Pack("brickfairytale")]
            public const Id
                Pebbles = (Id)1070,
                Tree = (Id)1071,
                Moss = (Id)1072,
                Cloud = (Id)1073,
                MushroomBlock = (Id)1074,
                Vine = (Id)468,
                Mushroom = (Id)469,
                WaterDrop = (Id)470;

            [Pack("brickfairytale", ForegroundType = ForegroundType.Morphable)]
            public const Id
                HalfBlockOrange = (Id)1075,
                HalfBlockGreen = (Id)1076,
                HalfBlockBlue = (Id)1077,
                HalfBlockPink = (Id)1078,
                Flowers = (Id)471;
        }

        public static class Spring2016
        {
            [Pack("brickspring2016")]
            public const Id
                Dirt = (Id)1081,
                Hedge = (Id)1082,
                LeftSlope = (Id)473,
                RightSlope = (Id)474;

            [Pack("brickspring2016", ForegroundType = ForegroundType.Morphable)]
            public const Id
                Daisy = (Id)475,
                Tulip = (Id)476,
                Daffodil = (Id)477;
        }

        public static class Summer2016
        {
            [Pack("bricksummer2016")]
            public const Id
                Beige = (Id)1083,
                Purple = (Id)1084,
                Yellow = (Id)1085,
                Teal = (Id)1086,
                OneWay = (Id)1087;

            [Pack("bricksummer2016", ForegroundType = ForegroundType.Morphable)]
            public const Id
                Flags = (Id)481,
                Awning = (Id)482,
                IceCream = (Id)483;
        }

        public static class SummerTrophy
        {
            [Pack("bricksummertrophybronze")]
            public const Id
                Bronze = (Id)484;
            [Pack("bricksummertrophysilver")]
            public const Id
                Silver = (Id)485;
            [Pack("bricksummertrophygold")]
            public const Id
                Gold = (Id)486;
        }

        public static class Restaurant
        {
            [Pack("brickrestaurant")]
            public const Id
                Hamburger = (Id)487,
                Hotdog = (Id)488,
                Sandwich = (Id)489,
                Soda = (Id)490,
                Fries = (Id)491;

            [Pack("brickrestaurant", ForegroundType = ForegroundType.Morphable)]
            public const Id
                Glass = (Id)492,
                Plate = (Id)493,
                Bowl = (Id)494;
        }

        public static class Mine
        {
            [Pack("brickmine")]
            public const Id
                Rocks = (Id)1093,
                Stalagmite = (Id)495,
                Stalagtite = (Id)496,
                Torch = (Id)498;

            [Pack("brickmine", ForegroundType = ForegroundType.Morphable)]
            public const Id
                Crystal = (Id)497;
        }

        public static class Halloween2016
        {
            [Pack("brickhalloween2016")]
            public const Id
                Grass = (Id)1501;

            [Pack("brickhalloween2016", ForegroundType = ForegroundType.Morphable)]
            public const Id
                Branch = (Id)499,
                Pumpkin = (Id)1500,
                Eyes = (Id)1502;
        }
        
        public static class Construction
        {
            public const Id
                Plywood = (Id)1096,
                Gravel = (Id)1097,
                Cement = (Id)1098,
                BeamHorizontal = (Id)1099,
                BeamVertical = (Id)1100,
                Sawhorse = (Id)1503,
                Cone = (Id)1504,
                Sign = (Id)1505;
        }

        public static class Christmas2016
        {
            [Pack("brickchristmas2016")]
            public const Id
                HalfBlockRed = (Id)1101,
                HalfBlockGreen = (Id)1102,
                HalfBlockWhite = (Id)1103,
                HalfBlockBlue = (Id)1104,
                HalfBlockYellow = (Id)1105,
                Bell = (Id)1508,
                Berries = (Id)1509,
                Candles = (Id)1510;

            [Pack("brickchristmas2016", ForegroundType = ForegroundType.Morphable)]
            public const Id
                LightDown = (Id)1507,
                LightUp = (Id)1506;
        }

        public static class Tile
        {
            [Pack("bricktiles")]
            public const Id
                White = (Id)1106,
                Gray = (Id)1107,
                Black = (Id)1108,
                Red = (Id)1109,
                Orange = (Id)1110,
                Yellow = (Id)1111,
                Green = (Id)1112,
                Cyan = (Id)1113,
                Blue = (Id)1114,
                Purple = (Id)1115;
        }

        public static class StPatricks2017
        {
            [Pack("brickstpatricks2017")]
            public const Id
                Clover = (Id)1511,
                PotOfGold = (Id)1512,
                Horseshoe = (Id)1513,
                RainbowLeft = (Id)1514,
                RainbowRight = (Id)1515;
        }

        public static class HalfBlock
        {
            [Pack("brickhalfblocks", ForegroundType = ForegroundType.Morphable)]
            public const Id
                Black = (Id)1116,
                Gray = (Id)1117,
                White = (Id)1118,
                Blue = (Id)1119,
                Purple = (Id)1120,
                Red = (Id)1121,
                Orange = (Id)1122,
                Yellow = (Id)1123,
                Green = (Id)1124,
                Cyan = (Id)1125;
        }
    }
}
