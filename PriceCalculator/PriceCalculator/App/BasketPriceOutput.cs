using PriceCalculator.App.Entities.Basket;
using System.Text;
using PriceCalculator.App.Interfaces;
using System;

namespace PriceCalculator.App.App
{
    public class BasketPriceWriter : IBasketPriceWriter
    {
        public string GetOutputString(CalculatedPrice calculatedPrice)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Subtotal: {ToMoneyString(calculatedPrice.Subtotal)}");
            if (calculatedPrice.SpecialOffersApplied.Count == 0)
            {
                output.AppendLine("(No offers available)");
            }
            else
            {
                foreach (var specialOfferApplied in calculatedPrice.SpecialOffersApplied)
                {
                    var productName = specialOfferApplied.SpecialOfferRule.SpecialOfferDiscountRule.Product.Description;
                    var percentageOff = specialOfferApplied.SpecialOfferRule.SpecialOfferDiscountRule.DiscountPercent;
                    var amountOff = decimal.Round(specialOfferApplied.DiscountedAmount, 2, MidpointRounding.AwayFromZero);
                    //Apples 10 % off: -10p
                    output.AppendLine($"{productName} {percentageOff}% off: -{ToMoneyString(amountOff)}");
                }
            }
            output.AppendLine("Total: " + ToMoneyString(calculatedPrice.Total));
            return output.ToString();
        }

        private string ToMoneyString(decimal value)
        {
            return (value < 1 ? $"{(int)(value * 100)}p" : $"{value:C}");
        }
    }
}
