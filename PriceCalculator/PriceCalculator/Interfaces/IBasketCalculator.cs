using PriceCalculator.App.Entities.Basket;

namespace PriceCalculator.App.Interfaces
{
    public interface IBasketCalculator
    {
        CalculatedPrice CalculatePrice(ShoppingBasket shoppingBasket);
    }
}
