namespace BotBits
{
    public static class Morph
    {
        public enum Id
        {
        }

        public static BotBits.Gravity ToGravity(this Id morph)
        {
            return (BotBits.Gravity)morph;
        }

        public static BotBits.Team ToTeam(this Id morph)
        {
            return (BotBits.Team)morph;
        }

        // Directions
        public static class Portal
        {
            public const Id
                Down = 0,
                Left = (Id)1,
                Up = (Id)2,
                Right = (Id)3;
        }

        public static class OneWay
        {
            public const Id
                Left = 0,
                Up = (Id)1,
                Right = (Id)2,
                Down = (Id)3;
        }

        public static class Spike
        {
            public const Id
                Left = 0,
                Up = (Id)1,
                Right = (Id)2,
                Down = (Id)3;
        }

        public static class MonsterTeeth
        {
            public const Id
                Left = 0,
                Up = (Id)1,
                Right = (Id)2,
                Down = (Id)3;
        }

        public static class HalfBlock
        {
            public const Id
                Left = 0,
                Down = (Id)1,
                Right = (Id)2,
                Up = (Id)3;
        }

        public static class Axe
        {
            public const Id
                TopRight = 0,
                TopLeft = (Id)1,
                BottomLeft = (Id)2,
                BottomRight = (Id)3;
        }

        public static class Sword
        {
            public const Id
                TopLeft = 0,
                BottomLeft = (Id)1,
                BottomRight = (Id)2,
                TopRight = (Id)3;
        }

        public static class SciFiSlope
        {
            public const Id
                TopLeft = 0,
                BottomLeft = (Id)1,
                BottomRight = (Id)2,
                TopRight = (Id)3;
        }


        public static class DomesticPipe
        {
            public const Id
                TopLeft = 0,
                BottomLeft = (Id)1,
                BottomRight = (Id)2,
                TopRight = (Id)3;
        }
        
        public static class Halloween2016Branch
        {
            public const Id
                TopLeft = 0,
                BottomLeft = (Id)1,
                BottomRight = (Id)2,
                TopRight = (Id)3;
        }

        // Orientation
        public static class SciFiStraight
        {
            public const Id
                Vertical = 0,
                Horizontal = (Id)1;
        }


        // Color
        public static class Dojo
        {
            public const Id
                Red = 0,
                Blue = (Id)1,
                Green = (Id)2;
        }

        public static class Medieval
        {
            public const Id
                Red = 0,
                Blue = (Id)1,
                Green = (Id)2,
                Yellow = (Id)3;
        }

        public static class DomesticVase
        {
            public const Id
                Blue = 0,
                Yellow = (Id)1,
                Orange = (Id)2,
                Red = (Id)3;
        }

        public static class DomesticTelevision
        {
            public const Id
                Yellow = 0,
                Black = (Id)1,
                Gray = (Id)2,
                Blue = (Id)3;
        }

        public static class DomesticWindow
        {
            public const Id
                Yellow = 0,
                Gray = (Id)1,
                Blue = (Id)2,
                Orange = (Id)3;
        }

        public static class FairytaleFlowers
        {
            public const Id
                Pink = 0,
                Blue = (Id)1,
                Orange = (Id)2;
        }

        public static class NewYear2015
        {
            public const Id
                Green = 0,
                Orange = (Id)1,
                Red = (Id)2,
                Purple = (Id)3;
        }

        public static class Spring2016Daisy
        {
            public const Id
                Violet = 0,
                White = (Id)1,
                Blue = (Id)2;
        }

        public static class Spring2016Tulip
        {
            public const Id
                Pink = 0,
                Red = (Id)1,
                Yellow = (Id)2;
        }

        public static class Spring2016Daffodil
        {
            public const Id
                Orange = 0,
                Yellow = (Id)1,
                White = (Id)2;
        }

        public static class Summer2016
        {
            public const Id
                Purple = 0,
                Red = (Id)1,
                Yellow = (Id)2,
                Green = (Id)3,
                Cyan = (Id)4,
                Blue = (Id)5;
        }
        
        public static class MineCrystal
        {
            public const Id
                Blue = 0,
                Red = (Id)1,
                Yellow = (Id)2,
                Green = (Id)3,
                Cyan = (Id)4;
        }

        public static class Halloween2016Eyes
        {
            public const Id
                Yellow = 0,
                Red = (Id)1,
                Purple = (Id)2,
                Green = (Id)3;
        }

        public static class Christmas2016
        {
            public const Id
                Purple = 0,
                Red = (Id)1,
                Yellow = (Id)2,
                Green = (Id)3,
                Cyan = (Id)4,
                Blue = (Id)5;
        }

        public static class Team
        {
            public const Id
                None = (Id)BotBits.Team.None,
                Red = (Id)BotBits.Team.Red,
                Blue = (Id)BotBits.Team.Blue,
                Green = (Id)BotBits.Team.Green,
                Cyan = (Id)BotBits.Team.Cyan,
                Magenta = (Id)BotBits.Team.Magenta,
                Yellow = (Id)BotBits.Team.Yellow;
        }

        public static class Gravity
        {
            public const Id
                Down = (Id)BotBits.Gravity.Down,
                Left = (Id)BotBits.Gravity.Left,
                Up = (Id)BotBits.Gravity.Up,
                Right = (Id)BotBits.Gravity.Right,
                Dot = (Id)BotBits.Gravity.Dot;
        }

        // Music
        public static class Piano
        {
            public const Id
                A0 = (Id)(-24),
                ASharp0 = (Id)(-23),
                B0 = (Id)(-22),
                C1 = (Id)(-24),
                CSharp1 = (Id)(-23),
                D1 = (Id)(-22),
                DSharp1 = (Id)(-21),
                E1 = (Id)(-20),
                F1 = (Id)(-19),
                FSharp1 = (Id)(-18),
                G1 = (Id)(-17),
                GSharp1 = (Id)(-16),
                A1 = (Id)(-15),
                ASharp1 = (Id)(-14),
                B1 = (Id)(-13),
                C2 = (Id)(-12),
                CSharp2 = (Id)(-11),
                D2 = (Id)(-10),
                DSharp2 = (Id)(-9),
                E2 = (Id)(-8),
                F2 = (Id)(-7),
                FSharp2 = (Id)(-6),
                G2 = (Id)(-5),
                GSharp2 = (Id)(-4),
                A2 = (Id)(-3),
                ASharp2 = (Id)(-2),
                B2 = (Id)(-1),
                C3 = 0,
                CSharp3 = (Id)1,
                D3 = (Id)2,
                DSharp3 = (Id)3,
                E3 = (Id)4,
                F3 = (Id)5,
                FSharp3 = (Id)6,
                G3 = (Id)7,
                GSharp3 = (Id)8,
                A3 = (Id)9,
                ASharp3 = (Id)10,
                B3 = (Id)11,
                C4 = (Id)12,
                CSharp4 = (Id)13,
                D4 = (Id)14,
                DSharp4 = (Id)15,
                E4 = (Id)16,
                F4 = (Id)17,
                FSharp4 = (Id)18,
                G4 = (Id)19,
                GSharp4 = (Id)20,
                A4 = (Id)21,
                ASharp4 = (Id)22,
                B4 = (Id)23,
                C5 = (Id)24,
                CSharp5 = (Id)25,
                D5 = (Id)26,
                DSharp5 = (Id)27,
                E5 = (Id)28,
                F5 = (Id)29,
                FSharp5 = (Id)30,
                G5 = (Id)31,
                GSharp5 = (Id)32,
                A5 = (Id)33,
                ASharp5 = (Id)34,
                B5 = (Id)35,
                C6 = (Id)36,
                CSharp6 = (Id)37,
                D6 = (Id)38,
                DSharp6 = (Id)39,
                E6 = (Id)40,
                F6 = (Id)41,
                FSharp6 = (Id)42,
                G6 = (Id)43,
                GSharp6 = (Id)44,
                A6 = (Id)45,
                ASharp6 = (Id)46,
                B6 = (Id)47,
                C7 = (Id)48,
                CSharp7 = (Id)49,
                D7 = (Id)50,
                DSharp7 = (Id)51,
                E7 = (Id)52,
                F7 = (Id)53,
                FSharp7 = (Id)54,
                G7 = (Id)55,
                GSharp7 = (Id)56,
                A7 = (Id)57,
                ASharp7 = (Id)58,
                B7 = (Id)59,
                C8 = (Id)60;
        }

        public static class Percussion
        {
            public const Id
                Base1 = 0,
                Base2 = (Id)1,
                Snare1 = (Id)2,
                Snare2 = (Id)3,
                Cymbal1 = (Id)4,
                Cymbal2 = (Id)5,
                Cymbal3 = (Id)6,
                Clap = (Id)7,
                Cymbal4 = (Id)8,
                Maraca = (Id)9;
        }

        public static class Guitar
        {
            public const Id
                HighE0 = 0,
                HighE1 = (Id)1,
                HighE2 = (Id)2,
                HighE3 = (Id)3,
                HighE4 = (Id)4,
                HighE5 = (Id)5,
                HighE6 = (Id)6,
                HighE7 = (Id)7,
                HighE8 = (Id)8,
                HighE9 = (Id)9,
                HighE10 = (Id)10,
                HighE11 = (Id)11,
                HighE12 = (Id)12,
                HighE13 = (Id)13,
                HighE14 = (Id)14,
                HighE15 = (Id)15,
                HighE16 = (Id)16,
                HighE17 = (Id)17,
                HighE18 = (Id)18,
                HighE19 = (Id)19,

                B0 = (Id)20,
                B1 = (Id)21,
                B2 = (Id)22,
                B3 = (Id)23,
                B4 = (Id)24,
                B5 = (Id)25,
                B6 = (Id)1,
                B7 = (Id)2,
                B8 = (Id)3,
                B9 = (Id)4,
                B10 = (Id)5,
                B11 = (Id)6,
                B12 = (Id)7,
                B13 = (Id)8,
                B14 = (Id)9,
                B15 = (Id)10,
                B16 = (Id)11,
                B17 = (Id)12,
                B18 = (Id)13,
                B19 = (Id)14,

                G0 = (Id)26,
                G1 = (Id)27,
                G2 = (Id)28,
                G3 = (Id)29,
                G4 = (Id)30,
                G5 = (Id)21,
                G6 = (Id)22,
                G7 = (Id)23,
                G8 = (Id)24,
                G9 = (Id)25,
                G10 = (Id)1,
                G11 = (Id)2,
                G12 = (Id)3,
                G13 = (Id)4,
                G14 = (Id)5,
                G15 = (Id)6,
                G16 = (Id)7,
                G17 = (Id)8,
                G18 = (Id)9,
                G19 = (Id)10,

                D0 = (Id)31,
                D1 = (Id)32,
                D2 = (Id)33,
                D3 = (Id)34,
                D4 = (Id)35,
                D5 = (Id)36,
                D6 = (Id)27,
                D7 = (Id)28,
                D8 = (Id)29,
                D9 = (Id)30,
                D10 = (Id)21,
                D11 = (Id)22,
                D12 = (Id)23,
                D13 = (Id)24,
                D14 = (Id)25,
                D15 = (Id)1,
                D16 = (Id)2,
                D17 = (Id)3,
                D18 = (Id)4,
                D19 = (Id)5,

                A0 = (Id)37,
                A1 = (Id)38,
                A2 = (Id)39,
                A3 = (Id)40,
                A4 = (Id)41,
                A5 = (Id)42,
                A6 = (Id)32,
                A7 = (Id)33,
                A8 = (Id)34,
                A9 = (Id)35,
                A10 = (Id)36,
                A11 = (Id)27,
                A12 = (Id)28,
                A13 = (Id)29,
                A14 = (Id)30,
                A15 = (Id)21,
                A16 = (Id)22,
                A17 = (Id)23,
                A18 = (Id)24,
                A19 = (Id)25,

                LowE0 = (Id)43,
                LowE1 = (Id)44,
                LowE2 = (Id)45,
                LowE3 = (Id)46,
                LowE4 = (Id)47,
                LowE5 = (Id)48,
                LowE6 = (Id)38,
                LowE7 = (Id)39,
                LowE8 = (Id)40,
                LowE9 = (Id)41,
                LowE10 = (Id)42,
                LowE11 = (Id)32,
                LowE12 = (Id)33,
                LowE13 = (Id)34,
                LowE14 = (Id)35,
                LowE15 = (Id)36,
                LowE16 = (Id)27,
                LowE17 = (Id)28,
                LowE18 = (Id)29,
                LowE19 = (Id)30;
        }

        // Misc
        public static class Sign
        {
            public const Id
                Wood = 0,
                Iron = (Id)1,
                Bronze = (Id)2,
                Gold = (Id)3;
        }

        public static class Summer2016IceCream
        {
            public const Id
                Mint = 0,
                Vanilla = (Id)1,
                Chocolate = (Id)2,
                Strawberry = (Id)3;
        }

        public static class DomesticPainting
        {
            public const Id
                Cabin = 0,
                River = (Id)1,
                Mountain = (Id)2,
                Sunset = (Id)3;
        }

        public static class DomesticLightBulb
        {
            public const Id
                StandingOff = 0,
                HangingOn = (Id)1,
                HangingOff = (Id)2,
                SandingOn = (Id)3;
        }
        
        public static class MedievalTimber
        {
            public const Id
                VSupport = 0,
                None = (Id)1,
                // ReSharper disable once InconsistentNaming
                TSupport = (Id)2,
                HorizontalSupport = (Id)3,
                LeftDiagonalSupport = (Id)4,
                RightDiagonalSupport = (Id)5;
        }

        public static class RestaurantGlass
        {
            public const Id
                OrangeJuice = 0,
                Empty = (Id)1,
                Water = (Id)2,
                Milk = (Id)3;
        }

        public static class RestaurantPlate
        {
            public const Id
                Fish = 0,
                Empty = (Id)1,
                Chicken = (Id)2,
                Ham = (Id)3;
        }

        public static class Halloween2015
        {
            public const Id
                On = 0,
                Off = (Id)1;
        }

        public static class Halloween2016Pumpkin
        {
            public const Id
                On = 0,
                Off = (Id)1;
        }

        public static class RestaurantBowl
        {
            public const Id
                IceCream = 0,
                HangingOn = (Id)1,
                Salad = (Id)2,
                Spaghetti = (Id)3;
        }
    }
}