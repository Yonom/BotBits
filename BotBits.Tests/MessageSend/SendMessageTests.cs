using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BotBits.SendMessages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BotBits.Tests.MessageSend
{
    [TestClass]
    public class SendMessageTests
    {
        [TestMethod]
        public void TestSendMessageSettings()
        {
            // if any sendmessages are invalid (not inheriting themselves, not sealed, etc.) this test fails

            var client = new BotBitsClient();
            var types = Assembly.GetAssembly(typeof(BotBitsClient)).GetTypes();
            var sendmsgs = types.Where(t => IsSubclassOfRawGeneric(typeof(SendMessage<>), t)).Where(t => !t.IsAbstract).ToList();
            sendmsgs.ForEach(s => typeof(SendMessage<>).MakeGenericType(s).GetMethod("Of").Invoke(null, new object[] {client}));
        }

        static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }
    }
}
