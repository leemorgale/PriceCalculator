using PriceCalculator.App.App;
using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.Basket;
using PriceCalculator.App.Interfaces;

namespace PriceCalculator.App
{
    public class AppMain : IAppMain
    {
        private readonly ProductsDL _productsDL;
        private readonly SpecialOffersDL _specialOffersDL;
        public AppMain(ProductsDL productsDL,
                   SpecialOffersDL specialOffersDL)
        {
            _productsDL = productsDL;
            _specialOffersDL = specialOffersDL;
        }
        public string Process(string[] args)
        {
            // read input from user
            IBasketInputReader basketInputReader = new BasketInputReader();
            ShoppingBasket shoppingBasket = basketInputReader.CreateBasketFromInput(args, _productsDL);

            // calculate snopping basket price
            IBasketCalculator basketCalculator = new BasketCalculator(_specialOffersDL);
            CalculatedPrice calculatedPrice = basketCalculator.CalculatePrice(shoppingBasket);

            // write output
            IBasketPriceWriter basketPriceWriter = new BasketPriceWriter();
            return basketPriceWriter.GetOutputString(calculatedPrice);
        }
    }
}
