namespace PriceCalculator.App.Entities.SpecialOffers
{
    public class SpecialOfferApplied
    {
        public SpecialOfferApplied(SpecialOfferRule specialOfferRule, decimal discountedAmount)
        {
            SpecialOfferRule = specialOfferRule;
            DiscountedAmount = discountedAmount;
        }

        public SpecialOfferRule SpecialOfferRule { get; private set; }
        public decimal DiscountedAmount { get; private set; }
    }
}
