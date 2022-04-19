using GoldenToolKit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoldenToolKitTests
{
    [TestClass]
    public class ModClassTest
    {
        [TestMethod]
        public void FactorialTest()
        {
            Assert.AreEqual(0, ModClass.ManualMod(10, 5));
            Assert.AreEqual(10, ModClass.ManualMod(60, 50));
            Assert.AreEqual(12, ModClass.ManualMod(12, 20));
            Assert.AreEqual(13, ModClass.ManualMod(13, 20));
            Assert.AreEqual(19, ModClass.ManualMod(19, 20));
            Assert.AreEqual(8, ModClass.ManualMod(228, 20));

        }
    }
}