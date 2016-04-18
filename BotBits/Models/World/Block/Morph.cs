namespace BotBits
{
    public static class Morph
    {
        public enum Id
        {
        }

        public static BotBits.Team ToTeam(this Id morph)
        {
            return (BotBits.Team) morph;
        }

        public static class Portal
        {
            public const Id
                Down = 0,
                Left = (Id) 1,
                Up = (Id) 2,
                Right = (Id) 3;
        }

        public static class OneWay
        {
            public const Id
                Left = 0,
                Up = (Id) 1,
                Right = (Id) 2,
                Down = (Id) 3;
        }

        public static class FairyOneWay
        {
            public const Id
                Left = 0,
                Down = (Id)1,
                Right = (Id)2,
                Up = (Id)3;
        }

        public static class Flowers
        {
            public const Id
                Pink = 0,
                Blue = (Id)1,
                Orange = (Id)2;
        }

        public static class HalfBlock
        {
            public const Id
                Left = 0,
                Down = (Id) 1,
                Right = (Id) 2,
                Up = (Id) 3;
        }

        public static class Spike
        {
            public const Id
                Left = 0,
                Up = (Id) 1,
                Right = (Id) 2,
                Down = (Id) 3;
        }

        public static class Dojo
        {
            public const Id
                Red = 0,
                Blue = (Id) 1,
                Green = (Id) 2;
        }

        public static class Medieval
        {
            public const Id
                Red = 0,
                Blue = (Id) 1,
                Green = (Id) 2,
                Yellow = (Id) 3;
        }

        public static class SciFiSlope
        {
            public const Id
                TopLeft = 0,
                BottomLeft = (Id) 1,
                BottomRight = (Id) 2,
                TopRight = (Id) 3;
        }

        public static class SciFiStraight
        {
            public const Id
                Vertical = 0,
                Horizontal = (Id) 1;
        }

        public static class Sword
        {
            public const Id
                TopLeft = 0,
                BottomLeft = (Id) 1,
                BottomRight = (Id) 2,
                TopRight = (Id) 3;
        }

        public static class Axe
        {
            public const Id
                TopRight = 0,
                TopLeft = (Id) 1,
                BottomLeft = (Id) 2,
                BottomRight = (Id) 3;
        }

        public static class Timber
        {
            public const Id
                VSupport = 0,
                None = (Id) 1,
                TSupport = (Id) 2,
                HorizontalSupport = (Id) 3,
                LeftDiagonalSupport = (Id) 4,
                RightDiagonalSupport = (Id) 5;
        }

        public static class Piano
        {
            public const Id
                A0 = (Id) (-24),
                ASharp0 = (Id) (-23),
                B0 = (Id) (-22),
                C1 = (Id) (-24),
                CSharp1 = (Id) (-23),
                D1 = (Id) (-22),
                DSharp1 = (Id) (-21),
                E1 = (Id) (-20),
                F1 = (Id) (-19),
                FSharp1 = (Id) (-18),
                G1 = (Id) (-17),
                GSharp1 = (Id) (-16),
                A1 = (Id) (-15),
                ASharp1 = (Id) (-14),
                B1 = (Id) (-13),
                C2 = (Id) (-12),
                CSharp2 = (Id) (-11),
                D2 = (Id) (-10),
                DSharp2 = (Id) (-9),
                E2 = (Id) (-8),
                F2 = (Id) (-7),
                FSharp2 = (Id) (-6),
                G2 = (Id) (-5),
                GSharp2 = (Id) (-4),
                A2 = (Id) (-3),
                ASharp2 = (Id) (-2),
                B2 = (Id) (-1),
                C3 = (Id) 0,
                CSharp3 = (Id) 1,
                D3 = (Id) 2,
                DSharp3 = (Id) 3,
                E3 = (Id) 4,
                F3 = (Id) 5,
                FSharp3 = (Id) 6,
                G3 = (Id) 7,
                GSharp3 = (Id) 8,
                A3 = (Id) 9,
                ASharp3 = (Id) 10,
                B3 = (Id) 11,
                C4 = (Id) 12,
                CSharp4 = (Id) 13,
                D4 = (Id) 14,
                DSharp4 = (Id) 15,
                E4 = (Id) 16,
                F4 = (Id) 17,
                FSharp4 = (Id) 18,
                G4 = (Id) 19,
                GSharp4 = (Id) 20,
                A4 = (Id) 21,
                ASharp4 = (Id) 22,
                B4 = (Id) 23,
                C5 = (Id) 24,
                CSharp5 = (Id) 25,
                D5 = (Id) 26,
                DSharp5 = (Id) 27,
                E5 = (Id) 28,
                F5 = (Id) 29,
                FSharp5 = (Id) 30,
                G5 = (Id) 31,
                GSharp5 = (Id) 32,
                A5 = (Id) 33,
                ASharp5 = (Id) 34,
                B5 = (Id) 35,
                C6 = (Id) 36,
                CSharp6 = (Id) 37,
                D6 = (Id) 38,
                DSharp6 = (Id) 39,
                E6 = (Id) 40,
                F6 = (Id) 41,
                FSharp6 = (Id) 42,
                G6 = (Id) 43,
                GSharp6 = (Id) 44,
                A6 = (Id) 45,
                ASharp6 = (Id) 46,
                B6 = (Id) 47,
                C7 = (Id) 48,
                CSharp7 = (Id) 49,
                D7 = (Id) 50,
                DSharp7 = (Id) 51,
                E7 = (Id) 52,
                F7 = (Id) 53,
                FSharp7 = (Id) 54,
                G7 = (Id) 55,
                GSharp7 = (Id) 56,
                A7 = (Id) 57,
                ASharp7 = (Id) 58,
                B7 = (Id) 59,
                C8 = (Id) 60;
        }

        public static class Percussion
        {
            public const Id
                Base1 = 0,
                Base2 = (Id) 1,
                Snare1 = (Id) 2,
                Snare2 = (Id) 3,
                Cymbal1 = (Id) 4,
                Cymbal2 = (Id) 5,
                Cymbal3 = (Id) 6,
                Clap = (Id) 7,
                Cymbal4 = (Id) 8,
                Maraca = (Id) 9;
        }

        public static class Team
        {
            public const Id
                None = (Id) BotBits.Team.None,
                Red = (Id) BotBits.Team.Red,
                Blue = (Id) BotBits.Team.Blue,
                Green = (Id) BotBits.Team.Green,
                Cyan = (Id) BotBits.Team.Cyan,
                Magenta = (Id) BotBits.Team.Magenta,
                Yellow = (Id) BotBits.Team.Yellow;
        }

        public static class LightBulb
        {
            public const Id
                StandingOff = 0,
                HangingOn = (Id) 1,
                HangingOff = (Id) 2,
                SandingOn = (Id) 3;
        }

        public static class Pipe
        {
            public const Id
                TopLeft = 0,
                BottomLeft = (Id) 1,
                BottomRight = (Id) 2,
                TopRight = (Id) 3;
        }

        public static class Painting
        {
            public const Id
                Cabin = 0,
                River = (Id) 1,
                Mountain = (Id) 2,
                Sunset = (Id) 3;
        }

        public static class Vase
        {
            public const Id
                Blue = 0,
                Yellow = (Id) 1,
                Orange = (Id) 2,
                Red = (Id) 3;
        }

        public static class Television
        {
            public const Id
                Yellow = 0,
                Black = (Id) 1,
                Gray = (Id) 2,
                Blue = (Id) 3;
        }

        public static class Window
        {
            public const Id
                Yellow = 0,
                Gray = (Id) 1,
                Blue = (Id) 2,
                Orange = (Id) 3;
        }

        public static class Light
        {
            public const Id
                On = 0,
                Off = (Id) 1;
        }

        public static class Jump
        {
            public const Id
                Disabled = 0,
                Single = (Id)1,
                Double = (Id)2;
        }

        public static class NewYear2015
        {
            public const Id
                Green = 0,
                Orange = (Id)1,
                Red = (Id)2,
                Purple = (Id)3;
        }

        public static class Sign
        {
            public const Id
                Wood = 0,
                Iron = (Id)1,
                Bronze = (Id)2,
                Gold = (Id)3;
        }

        public static class Daisy
        {
            public const Id
                Violet = 0,
                White = (Id)1,
                Blue = (Id)2;
        }

        public static class Tulip
        {
            public const Id
                Pink = 0,
                Red = (Id)1,
                Yellow = (Id)2;
        }

        public static class Daffodil
        {
            public const Id
                Orange = 0,
                Yellow = (Id)1,
                White = (Id)2;
        }
    }
}