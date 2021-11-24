using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskApp.Classes;
namespace TestAppTask
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckItemName()
        {
            var checkName = "learn";
            var item = new Item("learn");
            Assert.AreEqual(checkName,item.Title);
        }
    }
}
