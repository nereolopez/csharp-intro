using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.Tests.Stubs;

namespace MyClasses.Tests
{
    [TestClass]
    public class OrderManagerTests
    {
        [TestMethod]
        public void GetOrderNumberTest()
        {
            // Arrante
            var stub = new CounterStub();
            int expected = stub.Count;
            var orderManager = new OrderManager(stub);

            // Act:  
            int actual = orderManager.PlaceOrderAndGetOrderNumber();

            // Assert:  
            Assert.AreEqual(actual, expected);
        }
    }
    
}
