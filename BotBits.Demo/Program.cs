using System;
using System.Linq;
using System.Threading;
using BotBits.Events;

namespace BotBits.Demo
{
    internal class Program
    {
        private static BotBitsClient bot = new BotBitsClient();

        private static void Main()
        {

            var i = freeForAll.Length;
            EventLoader
                .Of(bot)
                .LoadStatic<Program>();

            ConnectionManager
                .Of(bot)
                .GuestLogin()
                .CreateJoinRoom("PWAARLDluVa0I");

            Thread.Sleep(-1);
        }

        protected static int[] freeForAll =
        {
            // Gravity
            0, 1, 2, 3, 4, 411, 412, 413, 414,
            // Crown
            5,
            // Keys
            6, 7, 8, 408, 409, 410,
            // Basic 
            9, 10, 11, 12, 1018, 13, 14, 15, 182,
            // Brick 
            1022, 16, 1023, 17, 18, 19, 20, 21, 1024,
            // Doors
            23, 24, 25, 1005, 1006, 1007,
            // Gates
            26, 27, 28, 1008, 1009, 1010,
            // Metal
            29, 30, 31,
            // Grass
            34, 35, 36,
            // Special
            22, 32, 33,
            // Coins
            100, 101,
            // Basic bg
            500, 501, 502, 503, 644, 504, 505, 506, 645,
            // Brick bg
            646, 507, 508, 647, 509, 510, 511, 512, 648
        };
    }
}