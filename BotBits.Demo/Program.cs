using System;
using System.Threading;
using BotBits.Events;
using PlayerIOClient;

namespace BotBits.Demo
{
    internal class Program
    {
        private static BotBitsClient bot = new BotBitsClient();
        private static BotBitsClient bot2 = new BotBitsClient();

        private static void Main()
        {
            EventLoader
                .Of(bot)
                .LoadStatic<Program>();

            ConnectionManager
                .Of(bot)
                .GuestLogin()
                .CreateJoinRoom("PW01");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}