using System;
using System.Linq;
using System.Threading;
using BotBits.Events;

namespace BotBits.Demo
{
    internal class Program
    {
        private static readonly BotBitsClient bot = new BotBitsClient();

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