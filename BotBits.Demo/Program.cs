using System.Threading;

namespace BotBits.Demo
{
    class Program
    {
        static BotBitsClient bot = new BotBitsClient();

        static void Main()
        {
            EventLoader
                .Of(bot)
                .LoadStatic<Program>();

            ConnectionManager
                .Of(bot)
                .GuestLogin()
                .CreateJoinRoom("PWAARLDluVa0I");

            Thread.Sleep(-1);
        }
    }
}