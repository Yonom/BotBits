using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BotBits.Tests.Events
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void BindTest()
        {
            var botBits = new BotBitsClient();
            var callback = new EventRaiseHandler<TestEvent>(delegate { });

            TestEvent
                .Of(botBits)
                .Bind(callback);

            Assert.IsTrue(
                TestEvent
                    .Of(botBits)
                    .Contains(callback));
        }

        [TestMethod]
        public void UnbindTest()
        {
            var botBits = new BotBitsClient();
            var callback = new EventRaiseHandler<TestEvent>(delegate { });

            TestEvent
                .Of(botBits)
                .Bind(callback);

            Assert.IsTrue(
                TestEvent
                    .Of(botBits)
                    .Unbind(callback));
        }

        [TestMethod]
        public void UnbindTest2()
        {
            var botBits = new BotBitsClient();
            var callback = new EventRaiseHandler<TestEvent>(delegate { });

            TestEvent
                .Of(botBits)
                .Bind(callback);

            TestEvent
                .Of(botBits)
                .Bind(callback);

            TestEvent
                .Of(botBits)
                .Bind(callback, EventPriority.High);

            TestEvent
                .Of(botBits)
                .Unbind(callback);

            Assert.AreEqual(2,
                TestEvent
                    .Of(botBits)
                    .Count);
        }

        [TestMethod]
        public void CountTest()
        {
            var botBits = new BotBitsClient();
            var callback = new EventRaiseHandler<TestEvent>(delegate { });

            TestEvent
                .Of(botBits)
                .Bind(callback);

            Assert.AreEqual(1,
                TestEvent
                    .Of(botBits)
                    .Count);

            TestEvent
                .Of(botBits)
                .Unbind(callback);

            Assert.AreEqual(0,
                TestEvent
                    .Of(botBits)
                    .Count);
        }

        [TestMethod]
        public void UnbindAllTest()
        {
            var botBits = new BotBitsClient();
            var callback = new EventRaiseHandler<TestEvent>(delegate { });

            TestEvent
                .Of(botBits)
                .Bind(callback);

            TestEvent
                .Of(botBits)
                .Bind(callback);

            TestEvent
                .Of(botBits)
                .Bind(callback, EventPriority.High);

            TestEvent
                .Of(botBits)
                .UnbindAll();

            Assert.AreEqual(0,
                TestEvent
                    .Of(botBits)
                    .Count);
        }

        [TestMethod]
        public void RaiseTest()
        {
            var isCalled = false;
            var callback = new EventRaiseHandler<TestEvent>(e => isCalled = true);
            var botBits = new BotBitsClient();

            TestEvent
                .Of(botBits)
                .Bind(callback);

            new TestEvent()
                .RaiseIn(botBits);

            Assert.IsTrue(isCalled);
        }

        [TestMethod]
        public void DoubleRaiseTest()
        {
            var botBits = new BotBitsClient();
            var e = new TestEvent();

            e.RaiseIn(botBits);

            try
            {
                e.RaiseIn(botBits);

                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            } // Expected
        }

        [TestMethod]
        public void PriorityTest()
        {
            var last = EventPriority.Highest;
            var check = new Action<EventPriority>(i =>
            {
                if (last > i)
                    Assert.Fail("Wrong order! Failed at: " + i);

                last = i;
            });
            var lowest = new EventRaiseHandler<TestEvent>(e => check(EventPriority.Lowest));
            var low = new EventRaiseHandler<TestEvent>(e => check(EventPriority.Low));
            var normal = new EventRaiseHandler<TestEvent>(e => check(EventPriority.Normal));
            var high = new EventRaiseHandler<TestEvent>(e => check(EventPriority.High));
            var highest = new EventRaiseHandler<TestEvent>(e => check(EventPriority.Highest));
            var botBits = new BotBitsClient();

            TestEvent.Of(botBits).Bind(highest, EventPriority.Highest);
            TestEvent.Of(botBits).Bind(lowest, EventPriority.Lowest);
            TestEvent.Of(botBits).Bind(high, EventPriority.High);
            TestEvent.Of(botBits).Bind(low, EventPriority.Low);
            TestEvent.Of(botBits).Bind(normal);

            new TestEvent().RaiseIn(botBits);
        }
    }
}