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
                .EmailLogin("guest1@tbp.com", "guest")
                .CreateJoinRoom("PW01");

            Thread.Sleep(Timeout.Infinite);

            switch (Morph.Axe.BottomLeft)
            {
                case Morph.Axe.BottomRight:
                    break;
            }
        }

        [EventListener]
        static void OnJoin(JoinEvent e)
        {
            Chat.Of(bot).PrivateMessage(e.Player, e.Username);
        }
    }
}