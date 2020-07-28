namespace PriceCalculator.App.Entities.SpecialOffers
{
    public class SpecialOfferDiscountRule
    {
        public SpecialOfferDiscountRule(Product.Product product, decimal discountPercent, int? maximumQuantity = null)
        {
            if (product == null)
            {
                throw new System.ArgumentNullException("product");
            }

            Product = product;
            DiscountPercent = discountPercent;
            MaximumQuantity = maximumQuantity;
        }

        public Product.Product Product { get; private set; }
        public decimal DiscountPercent { get; private set; }
        public int? MaximumQuantity { get; private set; }
    }
}
