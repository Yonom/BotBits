namespace BotBits
{
    // TODO: Verify ids
    public class Morph
    {
        public enum Id : ushort
        {
        }

        public static class Portal
        {
            public static Id
                Down = (Id)0,
                Left = (Id)1,
                Up = (Id)2,
                Right = (Id)3;
        }

        public static class OneWay
        {
            public static Id
                Left = (Id)0,
                Up = (Id)1,
                Right = (Id)2,
                Down = (Id)3;
        }

        public static class Spike
        {
            public static Id
                Left = (Id)0,
                Up = (Id)1,
                Right = (Id)2,
                Down = (Id)3;
        }

        public static class Dojo
        {
            public static Id
                Blue = (Id)0,
                Green = (Id)1,
                Red = (Id)2;
        }

        public static class Medieval
        {
            public static Id
                Blue = (Id)0,
                Green = (Id)1,
                Yellow = (Id)2,
                Red = (Id)3;
        }
                
        public static class SciFiSlope
        {
            public static Id
                InSouthEastPart = (Id)0,
                InSouthWestPart = (Id)1,
                InNorthWestPart = (Id)2,
                InNorthEastPart = (Id)3;
        }

        public static class SciFiStraight
        {
            public static Id
                Horizontal = (Id)0,
                Vertical = (Id)1;
        }

        public static class Sword
        {
            public static Id
                BottomLeft = (Id)0,
                BottomRight = (Id)1,
                TopRight = (Id)2,
                TopLeft = (Id)3;
        }

        public static class Axe
        {
            public static Id
                TopLeft = (Id)0,
                BottomLeft = (Id)1,
                BottomRight = (Id)2,
                TopRight = (Id)3;
        }

        public static class Timber
        {
            public static Id
                None = (Id)0,
                TSupport = (Id)1,
                HorizontalSupport = (Id)2,
                LeftDiagonalSupport = (Id)3,
                RightDiagonalSupport = (Id)4,
                VSupport = (Id)5;
        }

        public static class Piano
        {
            public static Id
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
            public static Id
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
