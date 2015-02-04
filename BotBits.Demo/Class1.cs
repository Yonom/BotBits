using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BotBits.Events;

namespace BotBits.Demo
{
    public class Class1
    {
        private static BotBitsClient _botBits;

        private static void Main()
        {
            _botBits = new BotBitsClient();
            EventLoader
                .Of(_botBits)
                .LoadStatic(typeof(Class1));

            Login();

            Thread.Sleep(Timeout.Infinite);
        }

        private static async void Login()
        {
            await ConnectionManager
                .Of(_botBits)
                .EmailLoginAsync("email", "pass")
                .CreateJoinRoomAsync("worldid");
            _botBits.Dispose();
        }

        [EventListener]
        private static void OnJoin(JoinEvent e)
        {
            Chat
                .Of(_botBits)
                .Say("{0}: Hello", e);
        }
    }
}