using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.Basket;
using PriceCalculator.App.Interfaces;
using PriceCalculator.App.Exceptions;
using PriceCalculator.App.Entities.Products;
using System.Globalization;

namespace PriceCalculator.App.App
{
    public class BasketInputReader : IBasketInputReader
    {
        public ShoppingBasket CreateBasketFromInput(string[] args, ProductsDL productsDL)
        {
            ShoppingBasket shoppingBasket = new ShoppingBasket();

            // check data is valid first
            if (productsDL == null)
            {
                throw new NoProductToBuyException("no products to purchase");
            }
            if(args == null || args.Length == 0)
            {
                return shoppingBasket;
            }

            // read arguments
            foreach (var arg in args)
            {
                string argToLower = arg.Trim().ToLower(CultureInfo.InvariantCulture);
                Product product = productsDL.GetProductByName(name: argToLower);
                if (product != null)
                {
                    shoppingBasket.AddItem(product);
                }
                else
                {
                    throw new InvalidInputException($"{argToLower} is not a valid product");
                }
            }
            return shoppingBasket;
        }
    }
}
