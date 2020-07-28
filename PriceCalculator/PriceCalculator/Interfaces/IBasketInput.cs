using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.Basket;

namespace PriceCalculator.App.Interfaces
{
    public interface IBasketInputReader
    {
        ShoppingBasket CreateBasketFromInput(string[] args, ProductsDL productsDL);
    }
}
