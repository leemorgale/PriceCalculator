using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.Basket;
using System.Text;
using PriceCalculator.App.Interfaces;

namespace PriceCalculator.App.App
{
    public class ShoppingBasketInput : IShoppingBasketInput
    {
        public ShoppingBasket CreateShoppingBasket(string[] args, Products products)
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
            }
            return shoppingBasket;
        }
    }
}
