using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using PriceCalculator.App;
using PriceCalculator.App.App;
using PriceCalculator.App.Entities.Basket;
using PriceCalculator.App.Exceptions;
using PriceCalculator.App.Interfaces;
using PriceCalculator.Test.Helpers;

namespace PriceCalculator.Test
{
    [TestClass]
    public class BasketInputReaderTests
    {
        [TestMethod]
        public void CheckShoppingBasketAddProductToBasket()
        {
            string[] args = { "Apple", "Milk", "Bread" };
            var products = TestDataHelper.GetProductsBeansBreadMilkApple();
            IBasketInputReader shoppingBasketInput = new BasketInputReader();

            ShoppingBasket shoppingBasket = shoppingBasketInput.CreateBasketFromInput(args, products);

            Assert.IsTrue(shoppingBasket.GetItemCountById(products.GetProductByName("Apple").Id) == 1);
            Assert.IsTrue(shoppingBasket.GetItemCountById(products.GetProductByName("Milk").Id) == 1);
            Assert.IsTrue(shoppingBasket.GetItemCountById(products.GetProductByName("Bread").Id) == 1);
            Assert.IsTrue(products.GetProductByName("Not In Basket") == null);
        }

        [TestMethod]
        public void CheckInvalidInputThrowsInvalidInputException()
        {
            string input = "Not In Product";
            string[] args = { input };
            var products = TestDataHelper.GetProductsBeansBreadMilkApple();
            IBasketInputReader shoppingBasketInput = new BasketInputReader();

            try
            {
                ShoppingBasket shoppingBasket = shoppingBasketInput.CreateBasketFromInput(args, products);
                Assert.Fail("Should have thrown InvalidProductArgumentException exception");
            }catch (InvalidInputException ex)
            {
                Assert.IsTrue(ex.Message.ToLower().Contains(input.ToLower()));
            }
        }

        [TestMethod]
        public void CheckNoProductToBuyIfNullThrowsNoProductToBuyException()
        {
            string input = "Not In Product";
            string[] args = { input };
            IBasketInputReader shoppingBasketInput = new BasketInputReader();

            try
            {
                ShoppingBasket shoppingBasket = shoppingBasketInput.CreateBasketFromInput(args, null);
                Assert.Fail("Should have thrown InvalidProductArgumentException exception");
            }
            catch (NoProductToBuyException ex)
            {
                Assert.IsTrue(ex.Message.ToLower().Contains("no products to purchase"));
            }
        }
    }
}
