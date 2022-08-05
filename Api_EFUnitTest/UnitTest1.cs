using EF_Api.Fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Api_EFUnitTest
{
    [TestClass]
    public class Tests
    {
      
        [TestMethod]
        public void Test1()
        {
            Arithematic arithematic = new Arithematic();
            Mock<Arithematic> mock = new Mock<Arithematic>();
            mock.Setup(x => x.CheckDigitOnly()).Returns(true);
            Assert.AreEqual(true, mock.Object.CheckDigitOnly());
        }
    }
}