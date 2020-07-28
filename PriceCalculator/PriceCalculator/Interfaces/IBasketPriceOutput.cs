using PriceCalculator.App.Entities.Basket;

namespace PriceCalculator.App.Interfaces
{
    public interface IBasketPriceWriter
    {
        string GetOutputString(CalculatedPrice calculatedPrice);
    }
}
