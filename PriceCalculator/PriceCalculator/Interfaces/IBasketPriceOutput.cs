using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.Basket;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.App.Interfaces
{
    public interface IBasketPriceOutput
    {
        string GetOutputString(CalculatedPrice shoppingBasketPrice);
    }
}
