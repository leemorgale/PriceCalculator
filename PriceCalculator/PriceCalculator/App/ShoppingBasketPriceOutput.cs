using PriceCalculator.App.Entities.Basket;
using PriceCalculator.App.Interfaces;
using System.Text;

namespace PriceCalculator.App.App
{
    public class ShoppingBasketPriceOutput : IShoppingBasketPriceOutput
    {
        public string GetOutputString(ShoppingBasketPrice shoppingBasketPrice)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Subtotal :" + shoppingBasketPrice.Subtotal);
            if (shoppingBasketPrice.SpecialOffersApplied.Count == 0)
            {
                output.AppendLine("(No offers available)");
            }
            else
            {
                foreach (var specialOfferApplied in shoppingBasketPrice.SpecialOffersApplied)
                {
                    var productName = specialOfferApplied.SpecialOfferRule.SpecialOfferDiscountRule.Product.Name;
                    var percentageOff = specialOfferApplied.SpecialOfferRule.SpecialOfferDiscountRule.DiscountPercent;
                    var amountOff = specialOfferApplied.DiscountedAmount;
                    //Apples 10 % off: -10p
                    output.AppendLine(string.Format("{0} {1} % off: {2}", productName, percentageOff, amountOff));
                }
            }
            output.AppendLine("Subtotal :" + shoppingBasketPrice.Total);
            return output.ToString();
        }
    }
}
