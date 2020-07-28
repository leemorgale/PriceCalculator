using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculator.App;
using PriceCalculator.App.Exceptions;
using PriceCalculator.App.Interfaces;

namespace PriceCalculator.Test
{
    [TestClass]
    public class AppMainTests
    {
        [TestMethod]
        public void TestAppleMilkBread_WithAppleSpecialOffer()
        {
            string[] args = { "Apple", "Milk", "Bread" };
            var products = TestDataHelper.TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £3.10"));
            Assert.IsTrue(output.Contains("Apples 10% off: -10p"));
            Assert.IsTrue(output.Contains("Total: £3.00"));
        }

        [TestMethod]
        public void TestAppleMilkBread_WithNoSpecialOffers()
        {
            string[] args = { "Apple", "Milk", "Bread" };
            var products = TestDataHelper.TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.TestDataHelper.EmptySpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £3.10"));
            Assert.IsTrue(output.Contains("(No offers available)"));
            Assert.IsTrue(output.Contains("Total: £3.10"));
        }

        [TestMethod]
        public void TestMilk_WithNoAvailbleOffers()
        {
            string[] args = { "Milk" };
            var products = TestDataHelper.TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £1.30"));
            Assert.IsTrue(output.Contains("(No offers available)"));
            Assert.IsTrue(output.Contains("Total: £1.30"));
        }

        [TestMethod]
        public void TestApple_WithSpecialOffers()
        {
            string[] args = { "Apple" };
            var products = TestDataHelper.TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £1.00"));
            Assert.IsTrue(output.Contains("Apples 10% off: -10p"));
            Assert.IsTrue(output.Contains("Total: 90p"));
        }

        [TestMethod]
        public void TestTwoBeans_WithHalfPriceBreadOffer()
        {
            string[] args = { "Beans", "Beans", "Bread" };
            var products = TestDataHelper.TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £2.10"));
            Assert.IsTrue(output.Contains("Bread 50% off: -40p"));
            Assert.IsTrue(output.Contains("Total: £1.70"));
        }

        [TestMethod]
        public void TestTwoBeans_WithHalfPriceNoBread()
        {
            string[] args = { "Beans", "Beans" };
            var products = TestDataHelper.TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £1.30"));
            Assert.IsTrue(output.Contains("(No offers available)"));
            Assert.IsTrue(output.Contains("Total: £1.30"));
        }

        [TestMethod]
        public void TestTwoBeansAndApple_WithHalfPriceBreadOffer()
        {
            string[] args = { "Beans", "Beans", "Bread", "Apple" };
            var products = TestDataHelper.TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £3.10"));
            Assert.IsTrue(output.Contains("Apples 10% off: -10p"));
            Assert.IsTrue(output.Contains("Bread 50% off: -40p"));
            Assert.IsTrue(output.Contains("Total: £2.60"));
        }

        [TestMethod]
        public void TestNoArgs_OutputsZeroTotals()
        {
            string[] args = { };
            var products = TestDataHelper.TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: 0p"));
            Assert.IsTrue(output.Contains("(No offers available)"));
            Assert.IsTrue(output.Contains("Total: 0p"));
        }

        [TestMethod]
        public void TestAppleMilkBread_WithNoProducts()
        {
            string[] args = { "Apple", "Milk", "Bread" };
            var products = TestDataHelper.TestDataHelper.EmptyProducts();
            var specialOffers = TestDataHelper.TestDataHelper.EmptySpecialOffers(products);

            try
            {
                IAppMain appMain = new AppMain(null, specialOffers);
                var output = appMain.Process(args);
                Assert.Fail("Should have thrown InvalidProductArgumentException exception");
            }
            catch (NoProductToBuyException ex)
            {
                Assert.IsTrue(ex.Message == "no products to purchase");
            }
        }
    }
}
