namespace PriceCalculator.App.Entities.SpecialOffers
{
    public class SpecialOfferMatchRule
    {
        public SpecialOfferMatchRule(Product.Product product, int minimumQuantity = 1)
        {
            if(product == null)
            {
                throw new System.ArgumentNullException("product");
            }

            MinimumQuantity = minimumQuantity;
            Product = product;
        }

        public Product.Product Product { get; private set; }
        public int MinimumQuantity { get; private set; }

    }
}
