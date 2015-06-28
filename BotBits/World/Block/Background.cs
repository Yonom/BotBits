using BotBits.Shop;

// ReSharper disable InconsistentNaming
namespace BotBits
{
    public static class Background
    {
        public enum Id : ushort
        {
        }

        public const Id
            Empty = 0;

        public static class Basic
        {
            public const Id
                Gray = (Id)500,
                Blue = (Id)501,
                Purple = (Id)502,
                Red = (Id)503,
                Orange = (Id)644,
                Yellow = (Id)504,
                Green = (Id)505,
                Cyan = (Id)506,
                Black = (Id)645;
        }

        public static class Brick
        {
            public const Id
                Gray = (Id)646,
                Orange = (Id)507,
                Blue = (Id)647,
                Teal = (Id)508,
                Purple = (Id)509,
                Green = (Id)510,
                Red = (Id)511,
                Tan = (Id)512,
                Black = (Id)648;
        }

        public static class Checker
        {
            [Pack("brickbgchecker")]
            public const Id
                Gray = (Id)513,
                Blue = (Id)514,
                Purple = (Id)515,
                Red = (Id)516,
                Yellow = (Id)517,
                Green = (Id)518,
                Cyan = (Id)519;
        }

        public static class Dark
        {
            [Pack("brickbgdark")]
            public const Id
                Gray = (Id)520,
                Blue = (Id)521,
                Purple = (Id)522,
                Red = (Id)523,
                Yellow = (Id)524,
                Green = (Id)525,
                Cyan = (Id)526;
        }

        public static class Pastel
        {
            [Pack("brickbgpastel")]
            public const Id
               Orange = (Id)527,
               Green = (Id)528,
               Lime = (Id)529,
               Cyan = (Id)530,
               Blue = (Id)531,
               Red = (Id)532;
        }

        public static class Canvas
        {
            [Pack("brickbgcanvas")]
            public const Id
                Orange = (Id)533,
                Tan = (Id)534,
                Gold = (Id)535,
                Lime = (Id)536,
                Cyan = (Id)537,
                Gray = (Id)538,
                Blue = (Id)606,
                Red = (Id)671,
                Purple = (Id)672;
        }

        public static class Candy
        {
            [Pack("brickcandy")]
            public const Id
                Pink = (Id)539,
                Blue = (Id)540;
        }

        public static class Halloween2011
        {
            [Pack("brickhw2011")]
            public const Id
               Gray = (Id)541,
               FullBrick = (Id)542,
               StairDown = (Id)543,
               StairUp   = (Id)544;
        }
        
        public static class Carnival
        {
            [Pack("brickbgcarnival")]
            public const Id
                RedStripe = (Id)545,
                BlueStripe = (Id)546,
                Pink = (Id)547,
                Checkered = (Id)548,
                Green = (Id)549,
                Yellow = (Id)558,
                RedWhiteStripe = (Id)563,
                Blue = (Id)607;

        }

        public static class Prison
        {
            [Pack("brickprison")]
            public const Id
                Wall = (Id)550,
                Picture = (Id)551,
                WindowBlue = (Id)552,
                WindowBlack = (Id)553;
        }

        public static class Pirate
        {
            [Pack("brickpirate")]
            public const Id
                Plank = (Id)554,
                LightPlank = (Id)555,
                DarkPlank = (Id)559,
                Flag = (Id)560;
        }

        public static class Stone
        {
            [Pack("brickstone")]
            public const Id
                FullBrick = (Id)561,
                HalfBrick = (Id)562;
        }


        public static class Dojo
        {
            [Pack("brickninja")]
            public const Id
                White = (Id)564,
                Gray = (Id)565,
                BlueShingles = (Id)566,
                DarkBlueShingles = (Id)567,
                RedShingles = (Id)667,
                DarkRedShingles = (Id)668,
                GreenShingles = (Id)669,
                DarkGreenShingles = (Id)670;
        }

        public static class WildWest
        {
            [Pack("brickcowboy")]
            public const Id
                LitBrown = (Id)568,
                DarkBrown = (Id)569,
                LitRed = (Id)570,
                DarkRed = (Id)571,
                LitBlue = (Id)572,
                DarkBlue = (Id)573;
        }

        public static class Water
        {
            [Pack("brickwater")]
            public const Id
                Plain = (Id)574,
                Octopus = (Id)575,
                Fish = (Id)576,
                SeaHorse = (Id)577,
                Seaweed = (Id)578;
        }

        public static class Sand
        {
            [Pack("bricksand")]
            public const Id
                LightYellow = (Id)579,
                Gray = (Id)580,
                DarkerYellow = (Id)581,
                Orange = (Id)582,
                LightBrown = (Id)583,
                DarkBrown = (Id)584;
        }

        public static class Industrial
        {
            [Pack("brickindustrial")]
            public const Id
               NoPlate = (Id)585,
               GrayPlate = (Id)586,
               BluePlate = (Id)587,
               GreenPlate = (Id)588,
               YellowPlate = (Id)589;
        }
        
        public static class Medieval
        {
            [Pack("brickmedieval")]
            public const Id
                Bricks = (Id)599,
                Planks = (Id)600,
                ThatchRoof = (Id)590,
                RedShingles = (Id)591,
                TealShingles = (Id)592,
                BrownShingles = (Id)556,
                Wallpaper = (Id)593;
        }

        public static class OuterSpace
        {
            [Pack("brickrocket")]
            public const Id
                White = (Id)601,
                Blue = (Id)602,
                Green = (Id)603,
                Red = (Id)604;
        }

        public static class Monster
        {
            [Pack("brickmonster")]
            public const Id
                GreenFur = (Id)608,
                DarkGreenFur = (Id)609,
                RedFur = (Id)663,
                DarkRedFur = (Id)664,
                PurpleFur = (Id)665,
                DarkPurpleFur = (Id)666;
        }

        public static class Normal
        {
            [Pack("brickbgnormal")]
            public const Id
                Gray = (Id)610,
                Blue = (Id)611,
                Purple = (Id)612,
                Red = (Id)613,
                Yellow = (Id)614,
                Green = (Id)615,
                Cyan = (Id)616;
        }

        public static class Jungle
        {
            [Pack("brickjungle")]
            public const Id
                Gray = (Id)617,
                Red = (Id)618,
                Blue = (Id)619,
                Yellow = (Id)620,
                BrightPlants = (Id)621,
                Plants = (Id)622,
                DarkPlants = (Id)623;
        }

        public static class Christmas2012
        {
            [Pack("brickxmas2012")]
            public const Id
                Yellow = (Id)624,
                Green = (Id)625,
                Blue = (Id)626;
        }

        public static class Lava
        {
            [Pack("bricklava")]
            public const Id
                Yellow = (Id)627,
                Orange = (Id)628,
                Red = (Id)629;
        }

        public static class Swamp
        {
            [Pack("brickswamp")]
            public const Id
                Dirt = (Id)557,
                Underbrush = (Id)630;
        }

        // 6 ids skipped

        public static class SciFi
        {
            [Pack("brickscifi")]
            public const Id
                Gray = (Id)637;
        }

        public static class Sparta
        {
            [Pack("bricksparta")]
            public const Id
                Gray = (Id)638,
                Green = (Id)639,
                Red = (Id)640;
        }

        public static class Autumn2014
        {
            [Pack("brickautumn2014")]
            public const Id
                Yellow = (Id)641,
                Orange = (Id)642,
                Red = (Id)643;
        }

        public static class Clay
        {
            [Pack("brickclay")]
            public const Id
                Plain = (Id)594,
                Brick = (Id)595,
                Diamond = (Id)596,
                Cross = (Id)597,
                Deteriorated = (Id)598;
        }

        public static class Neon
        {
            [Pack("brickneon")]
            public const Id
                Blue = (Id)605,
                Orange = (Id)673,
                Green = (Id)674,
                Red = (Id)675;
        }
    }
}