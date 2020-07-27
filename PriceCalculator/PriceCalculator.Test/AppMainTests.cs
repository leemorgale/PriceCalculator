using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculator.App;
using PriceCalculator.App.Interfaces;

namespace PriceCalculator.Test
{
    [TestClass]
    public class AppMainTests
    {
        [TestMethod]
        public void TestAppleMilkBread_WithSpecialOffers()
        {
            string[] args = { "Apple", "Milk", "Bread" };
            var products = TestDataHelper.TestDataHelper.GetProductSet1();
            var specialOffers = TestDataHelper.TestDataHelper.GetSpecialOffersSet1(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: �3.10"));
            Assert.IsTrue(output.Contains("Apples 10% off: -10p"));
            Assert.IsTrue(output.Contains("Total: �3.00"));
        }

        public void TestMilk_WithSpecialOffers()
        {
            string[] args = { "Milk" };
            var products = TestDataHelper.TestDataHelper.GetProductSet1();
            var specialOffers = TestDataHelper.TestDataHelper.GetSpecialOffersSet1(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: �1.30"));
            Assert.IsTrue(output.Contains("(No offers available)"));
            Assert.IsTrue(output.Contains("Total: �1.30"));
        }

        public void TestApple_WithSpecialOffers()
        {
            string[] args = { "Milk" };
            var products = TestDataHelper.TestDataHelper.GetProductSet1();
            var specialOffers = TestDataHelper.TestDataHelper.GetSpecialOffersSet1(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: �1.30"));
            Assert.IsTrue(output.Contains("(No offers available)"));
            Assert.IsTrue(output.Contains("Total: �1.30"));
        }
    }
}
