using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculator.App;
using PriceCalculator.App.Exceptions;
using PriceCalculator.App.Interfaces;
using PriceCalculator.Test.Helpers;

namespace PriceCalculator.Test
{
    [TestClass]
    public class AppMainTests
    {
        [TestMethod]
        public void TestSet1AppleMilkBreadWithAppleSpecialOffer()
        {
            string[] args = { "Apple", "Milk", "Bread" };
            var products = TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £3.10"));
            Assert.IsTrue(output.Contains("Apples 10% off: -10p"));
            Assert.IsTrue(output.Contains("Total: £3.00"));
        }

        [TestMethod]
        public void TestSet1AppleMilkBreadWithNoSpecialOffers()
        {
            string[] args = { "Apple", "Milk", "Bread" };
            var products = TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.EmptySpecialOffers();
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £3.10"));
            Assert.IsTrue(output.Contains("(No offers available)"));
            Assert.IsTrue(output.Contains("Total: £3.10"));
        }

        [TestMethod]
        public void TestSet1MilkWithNoAvailbleOffers()
        {
            string[] args = { "Milk" };
            var products = TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £1.30"));
            Assert.IsTrue(output.Contains("(No offers available)"));
            Assert.IsTrue(output.Contains("Total: £1.30"));
        }

        [TestMethod]
        public void TestSet1AppleWithSpecialOffers()
        {
            string[] args = { "Apple" };
            var products = TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £1.00"));
            Assert.IsTrue(output.Contains("Apples 10% off: -10p"));
            Assert.IsTrue(output.Contains("Total: 90p"));
        }

        [TestMethod]
        public void TestSet1TwoBeansWithHalfPriceBreadOffer()
        {
            string[] args = { "Beans", "Beans", "Bread" };
            var products = TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £2.10"));
            Assert.IsTrue(output.Contains("Bread 50% off: -40p"));
            Assert.IsTrue(output.Contains("Total: £1.70"));
        }

        [TestMethod]
        public void TestSet1TwoBeansWithHalfPriceNoBread()
        {
            string[] args = { "Beans", "Beans" };
            var products = TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £1.30"));
            Assert.IsTrue(output.Contains("(No offers available)"));
            Assert.IsTrue(output.Contains("Total: £1.30"));
        }

        [TestMethod]
        public void TestSet1TwoBeansAndAppleWithHalfPriceBreadOffer()
        {
            string[] args = { "Beans", "Beans", "Bread", "Apple" };
            var products = TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £3.10"));
            Assert.IsTrue(output.Contains("Apples 10% off: -10p"));
            Assert.IsTrue(output.Contains("Bread 50% off: -40p"));
            Assert.IsTrue(output.Contains("Total: £2.60"));
        }

        [TestMethod]
        public void TestSet1NoArgsOutputsZeroTotals()
        {
            string[] args = { };
            var products = TestDataHelper.GetProductsBeansBreadMilkApple();
            var specialOffers = TestDataHelper.GetAppleBeansBreadSpecialOffers(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: 0p"));
            Assert.IsTrue(output.Contains("(No offers available)"));
            Assert.IsTrue(output.Contains("Total: 0p"));
        }

        [TestMethod]
        public void TestSet2TestAppleMilkBreadWithNoProducts()
        {
            string[] args = { "Apple", "Milk", "Bread" };
            var specialOffers = TestDataHelper.EmptySpecialOffers();

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

        [TestMethod]
        public void TestSet33Oranges1appleFree90percentoffstrawberries()
        {
            string[] args = { "apple","orange","orange","orange", "strawberries" };
            var products = TestDataHelper.GetProductBeansStrawberriesMilkApplesOranges();
            var specialOffers = TestDataHelper.GetSpecialOffers3oranges1applefree(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £5.40"));
            Assert.IsTrue(output.Contains("Strawberries 90% off: -72p"));
            Assert.IsTrue(output.Contains("Apples 100% off: -£1.00"));
            Assert.IsTrue(output.Contains("Total: £3.68"));
        }

        [TestMethod]
        public void TestSet3NoOffers()
        {
            string[] args = { "apple", "orange", "orange" };
            var products = TestDataHelper.GetProductBeansStrawberriesMilkApplesOranges();
            var specialOffers = TestDataHelper.GetSpecialOffers3oranges1applefree(products);
            IAppMain appMain = new AppMain(products, specialOffers);
            var output = appMain.Process(args);

            Assert.IsTrue(output.Contains("Subtotal: £3.40"));
            Assert.IsTrue(output.Contains("(No offers available)"));
            Assert.IsTrue(output.Contains("Total: £3.40"));
        }
    }
}
