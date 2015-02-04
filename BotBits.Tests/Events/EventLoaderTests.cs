using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BotBits.Tests.Events
{
    [TestClass]
    public class EventLoaderTests
    {
        [TestMethod]
        public void EventLoadTest()
        {
            var botBits = new BotBitsClient();

            EventLoader
                .Of(botBits)
                .Load(this);

            Assert.IsTrue(
                TestEvent
                    .Of(botBits)
                    .Contains(this.OnTest));
        }

        [TestMethod]
        public void EventLoadStaticTest()
        {
            var botBits = new BotBitsClient();

            EventLoader
                .Of(botBits)
                .LoadStatic(typeof(EventLoaderTests));

            Assert.IsTrue(
                TestEvent
                    .Of(botBits)
                    .Contains(OnStaticTest));
        }

        [EventListener]
        private void OnTest(TestEvent e)
        {

        }

        [EventListener]
        private static void OnStaticTest(TestEvent e)
        {

        }
    }
}
