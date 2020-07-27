namespace PriceCalculator.App.Entities.SpecialOffers
{
    public class SpecialOfferRule
    {
        public SpecialOfferRule(SpecialOfferMatchRule specialOfferMatchRule, SpecialOfferDiscountRule specialOfferDiscountRule)
        {
            SpecialOfferDiscountRule = specialOfferDiscountRule;
            SpecialOfferMatchRule = specialOfferMatchRule;
        }
        public SpecialOfferMatchRule SpecialOfferMatchRule { get; private set; }
        public SpecialOfferDiscountRule SpecialOfferDiscountRule { get; private set; }
    }
}
