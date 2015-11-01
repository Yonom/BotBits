using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BotBits.Tests.Metadata
{
    [TestClass]
    public class MetadataTests
    {
        [TestMethod]
        public void MetadataChangedTest()
        {
            const string id = "test";
            const string value = "testvalue";

            var metadataObj = new MetadataTestObject();
            var changed = false;
            metadataObj.MetadataChanged += (sender, args) =>
            {
                if (args.Key != id)
                    Assert.Fail("Key not same.");
                if ((string) args.NewValue != value)
                    Assert.Fail("NewValue not same.");
                if (args.OldValue != null)
                    Assert.Fail("OldValue not null.");

                changed = true;
            };

            metadataObj.Set(id, value);

            Assert.IsTrue(changed);
        }

        [TestMethod]
        public void MetadataGetTest()
        {
            const string id = "test";
            const string value = "testvalue";

            var metadataObj = new MetadataTestObject();

            metadataObj.Set(id, value);

            Assert.AreEqual(value, metadataObj.Get<string>(id));
        }
    }
}