using PriceCalculator.App.Entities.Products;

namespace PriceCalculator.App.Entities.SpecialOffers
{
    public class SpecialOfferDiscountRule
    {
        public SpecialOfferDiscountRule(Product product, decimal discountPercent, int? maximumQuantity = null)
        {
            Product = product ?? throw new System.ArgumentNullException(nameof(product));
            DiscountPercent = discountPercent;
            MaximumQuantity = maximumQuantity;
        }

        public Product Product { get; private set; }
        public decimal DiscountPercent { get; private set; }
        public int? MaximumQuantity { get; private set; }
    }
}
