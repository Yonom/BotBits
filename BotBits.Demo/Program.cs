using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BotBits;
using BotBits.Events;

namespace BotBits.Demo
{
    internal class Program
    {
        private static BotBitsClient bot = new BotBitsClient();

        private static void Main()
        {
            ConnectionManager
                .Of(bot)
                .GuestLoginAsync()
                .CreateJoinRoomAsync("world");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}