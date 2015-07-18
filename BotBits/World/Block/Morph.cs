namespace BotBits
{
    public class Morph
    {
        public enum Id
        {
        }

        public static class Portal
        {
            public const Id
                Down = (Id)0,
                Left = (Id)1,
                Up = (Id)2,
                Right = (Id)3;
        }

        public static class OneWay
        {
            public const Id
                Left = (Id)0,
                Up = (Id)1,
                Right = (Id)2,
                Down = (Id)3;
        }

        public static class Spike
        {
            public const Id
                Left = (Id)0,
                Up = (Id)1,
                Right = (Id)2,
                Down = (Id)3;
        }

        public static class Dojo
        {
            public const Id
                Red = (Id)0,
                Blue = (Id)1,
                Green = (Id)2;
        }

        public static class Medieval
        {
            public const Id
                Red = (Id)0,
                Blue = (Id)1,
                Green = (Id)2,
                Yellow = (Id)3;
        }
                
        public static class SciFiSlope
        {
            public const Id
                TopLeft = (Id)0,
                BottomLeft = (Id)1,
                BottomRight = (Id)2,
                TopRight = (Id)3;
        }

        public static class SciFiStraight
        {
            public const Id
                Vertical = (Id)0,
                Horizontal = (Id)1;
        }

        public static class Sword
        {
            public const Id
                TopLeft = (Id)0,
                BottomLeft = (Id)1,
                BottomRight = (Id)2,
                TopRight = (Id)3;
        }

        public static class Axe
        {
            public const Id
                TopRight = (Id)0,
                TopLeft = (Id)1,
                BottomLeft = (Id)2,
                BottomRight = (Id)3;
        }

        public static class Timber
        {
            public const Id
                VSupport = (Id)0,
                None = (Id)1,
                TSupport = (Id)2,
                HorizontalSupport = (Id)3,
                LeftDiagonalSupport = (Id)4,
                RightDiagonalSupport = (Id)5;
        }

        public static class Piano
        {
            public const Id
                C1 = (Id)1,
                Csharp1 = (Id)2,
                D1 = (Id)3,
                Dsharp1 = (Id)4,
                E1 = (Id)5,
                F1 = (Id)6,
                Fsharp1 = (Id)7,
                G1 = (Id)8,
                Gsharp1 = (Id)9,
                A1 = (Id)10,
                Asharp1 = (Id)11,
                B1 = (Id)12,
                C2 = (Id)13,
                Csharp2 = (Id)14,
                D2 = (Id)15,
                Dsharp2 = (Id)16,
                E2 = (Id)17,
                F2 = (Id)18,
                Fsharp2 = (Id)19,
                G2 = (Id)20,
                Gsharp2 = (Id)21,
                A2 = (Id)22,
                Asharp2 = (Id)23,
                B2 = (Id)24,
                C3 = (Id)25;
        }

        public static class Percussion
        {
            public const Id
                Base1 = (Id)0,
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
    }
}
