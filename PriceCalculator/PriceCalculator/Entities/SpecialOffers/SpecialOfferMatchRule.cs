using PriceCalculator.App.Entities.Products;

namespace PriceCalculator.App.Entities.SpecialOffers
{
    public class SpecialOfferMatchRule
    {
        public SpecialOfferMatchRule(Product product, int minimumQuantity = 1)
        {
            MinimumQuantity = minimumQuantity;
            Product = product ?? throw new System.ArgumentNullException(nameof(product));
        }

        public Product Product { get; private set; }
        public int MinimumQuantity { get; private set; }

    }
}
