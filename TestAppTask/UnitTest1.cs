using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskApp.Classes;
using TaskApp.Interfaces;

namespace TestAppTask
{
    [TestClass]
    public class UnitTest1
    {
        IEditable _testHandler;

        public UnitTest1()
        {
            var x = new Mock<IEditable>();
            x.Setup(mockReader => mockReader.AddItem(new Item("new task")));
            _testHandler = x.Object;
        }

        [TestMethod]
        public void CheckItemName()
        {
            var checkName = "learn";
            var item = new Item("learn");
            Assert.AreEqual(checkName,item.Title);
        }
        [TestMethod]
        public void AddItem_Check()
        {
            _testHandler;
            Assert.AreEqual(checkName, item.Title);
        }

    }
}
