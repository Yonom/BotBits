using System;
using System.Diagnostics;
using System.Threading;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits.Demo
{
    internal class Program
    {
        private static BotBitsClient bot = new BotBitsClient();

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

        [EventListener]
        static void OnJoin(JoinEvent e)
        {
            Chat.Of(bot).PrivateMessage(e.Player, e.Username);
        }
    }
}