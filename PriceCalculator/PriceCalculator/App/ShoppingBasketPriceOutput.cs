using PriceCalculator.App.Entities.Basket;
using System.Text;
using PriceCalculator.App.Interfaces;
using System;

namespace PriceCalculator.App.App
{
    public class ShoppingBasketPriceOutput : IShoppingBasketPriceOutput
    {
        public string GetOutputString(ShoppingBasketPrice shoppingBasketPrice)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Subtotal: " + ToMoneyString(shoppingBasketPrice.Subtotal));
            if (shoppingBasketPrice.SpecialOffersApplied.Count == 0)
            {
                output.AppendLine("(No offers available)");
            }
            else
            {
                foreach (var specialOfferApplied in shoppingBasketPrice.SpecialOffersApplied)
                {
                    var productName = specialOfferApplied.SpecialOfferRule.SpecialOfferDiscountRule.Product.Description;
                    var percentageOff = specialOfferApplied.SpecialOfferRule.SpecialOfferDiscountRule.DiscountPercent;
                    var amountOff = decimal.Round(specialOfferApplied.DiscountedAmount, 2, MidpointRounding.AwayFromZero);
                    //Apples 10 % off: -10p
                    output.AppendLine(string.Format("{0} {1}% off: -{2}", productName, percentageOff, ToMoneyString(amountOff)));
                }
            }
            output.AppendLine("Total: " + ToMoneyString(shoppingBasketPrice.Total));
            return output.ToString();
        }

        private string ToMoneyString(decimal value)
        {
            return (value < 1 ? $"{(int)(value * 100)}p" : $"{value:C}");
        }
    }
}
