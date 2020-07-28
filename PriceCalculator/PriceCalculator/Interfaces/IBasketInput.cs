using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.Basket;

namespace PriceCalculator.App.Interfaces
{
    public interface IBasketInput
    {
        ShoppingBasket CreateShoppingBasketFromInput(string[] args, Products products);
    }
}
