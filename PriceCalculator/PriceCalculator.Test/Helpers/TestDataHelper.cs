using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.Products;
using PriceCalculator.App.Entities.SpecialOffers;
using System.Collections.Generic;

namespace PriceCalculator.Test.Helpers
{
    public static class TestDataHelper
    {
        public static ProductsDL GetProductsBeansBreadMilkApple()
        {
            Product beans = new Product(1, "Beans", 0.65m);
            Product bread = new Product(2, "Bread", 0.80m);
            Product milk = new Product(3, "Milk", 1.30m);
            Product apples = new Product(4, "Apple", "Apples", 1.00m);
            return new ProductsDL(new List<Product>() { beans, bread, milk, apples }); 
        }

        public static SpecialOffersDL GetAppleBeansBreadSpecialOffers(ProductsDL productsDL)
        {
            // 10 % off apples
            SpecialOfferRule apples10percentOff = new SpecialOfferRule(new SpecialOfferMatchRule(productsDL.GetProductByName("apple"), 1),
                   new SpecialOfferDiscountRule(productsDL.GetProductByName("apple"), 10));

            // buy 2 cans of beans, get 1 loaf of bread 50% off
            SpecialOfferRule twoCans1BreadLoaf = new SpecialOfferRule(new SpecialOfferMatchRule(productsDL.GetProductByName("beans"), 2),
                                new SpecialOfferDiscountRule(productsDL.GetProductByName("bread"), 50, 1));
            SpecialOffersDL specialOffers = new SpecialOffersDL(new List<SpecialOfferRule>() { apples10percentOff, twoCans1BreadLoaf });
            return specialOffers;
        }

        public static ProductsDL EmptyProducts()
        {
            return new ProductsDL(new List<Product>() { });
        }

        public static SpecialOffersDL EmptySpecialOffers()
        {
            return new SpecialOffersDL(new List<SpecialOfferRule>() { });
        }

        public static ProductsDL GetProductBeansStrawberriesMilkApplesOranges()
        {
            Product beans = new Product(1, "Beans", 0.65m);
            Product strawberries = new Product(2, "Strawberries", 0.80m);
            Product milk = new Product(3, "Milk", 1.30m);
            Product apples = new Product(4, "Apple", "Apples", 1.00m);
            Product oranges = new Product(5, "orange", "Oranges", 1.20m);
            return new ProductsDL(new List<Product>() { beans, strawberries, milk, apples, oranges });
        }

        public static SpecialOffersDL GetSpecialOffers3oranges1applefree(ProductsDL products)
        {
            // buy 90 % off strawberries
            SpecialOfferRule apples10percentOff = new SpecialOfferRule(
                    new SpecialOfferMatchRule(products.GetProductByName("Strawberries"), 1),
                    new SpecialOfferDiscountRule(products.GetProductByName("Strawberries"), 90));

            // buy 3 oranges, get 1 apple for free
            SpecialOfferRule threeOrangesOneAppleFree = new SpecialOfferRule(
                   new SpecialOfferMatchRule(products.GetProductByName("oranges"), 3),
                   new SpecialOfferDiscountRule(products.GetProductByName("apple"), 100, 1));

            SpecialOffersDL specialOffers = new SpecialOffersDL(new List<SpecialOfferRule>() { apples10percentOff, threeOrangesOneAppleFree });
            return specialOffers;
        }
    }
}
