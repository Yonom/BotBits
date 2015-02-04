using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BotBits.Tests.Packages
{
    [TestClass]
    public class PackageLoaderTests
    {
        [TestMethod]
        public void PackageLoadTest()
        {
            using (var loader = new PackageLoader())
            {
                loader.AddPackages(null, new AssemblyCatalog(Assembly.GetExecutingAssembly()), null);

                Assert.IsNull(loader.Get<TestPackage>().BotBits);
            }
        }

        [TestMethod]
        public void DisposeTest()
        {
            TestPackage package;
            using (var loader = new PackageLoader())
            {
                loader.AddPackages(null, new AssemblyCatalog(Assembly.GetExecutingAssembly()), null);
                package = loader.Get<TestPackage>();
            }

            Assert.IsTrue(package.IsDisposed);
        }
    }
}