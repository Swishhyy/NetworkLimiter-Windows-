using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkLimit.Config;

namespace NetworkLimit.Tests
{
    [TestClass]
    public class NetworkLimitTests
    {
        [TestMethod]
        public void TestApplyThrottle()
        {
            NetworkManager.ApplyThrottle("Ethernet", 1000);
            Assert.IsTrue(true); // Placeholder to verify no exceptions are thrown
        }

        [TestMethod]
        public void TestRemoveThrottle()
        {
            NetworkManager.RemoveThrottle("Ethernet");
            Assert.IsTrue(true); // Placeholder to verify no exceptions are thrown
        }

        [TestMethod]
        public void TestConfigLoading()
        {
            var config = ConfigLoader.LoadConfig();
            Assert.IsNotNull(config);
            Assert.AreEqual("Ethernet", config.NetworkInterface);
        }
    }
}
