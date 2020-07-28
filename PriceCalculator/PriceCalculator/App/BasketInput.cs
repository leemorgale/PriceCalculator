using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.Basket;
using System.Text;
using PriceCalculator.App.Interfaces;
using PriceCalculator.App.Exceptions;

namespace PriceCalculator.App.App
{
    public class BasketInput : IBasketInput
    {
        public ShoppingBasket CreateShoppingBasketFromInput(string[] args, Products products)
        {
            ShoppingBasket shoppingBasket = new ShoppingBasket();
            foreach (var arg in args)
            {
                var input = arg.Trim().ToLower();
                var product = products.GetProductByName(input);
                if (product != null)
                {
                    shoppingBasket.AddItem(product);
                }
                else
                {
                    throw new InvalidInputException(input + " is not a valid product");
                }
            }
            return shoppingBasket;
        }
    }
}
