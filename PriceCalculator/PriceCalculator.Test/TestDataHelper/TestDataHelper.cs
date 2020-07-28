using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.Product;
using PriceCalculator.App.Entities.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Test.TestDataHelper
{
    public static class TestDataHelper
    {
        public static Products GetProductsBeansBreadMilkApple()
        {
            Product beans = new Product(1, "Beans", 0.65m);
            Product bread = new Product(2, "Bread", 0.80m);
            Product milk = new Product(3, "Milk", 1.30m);
            Product apples = new Product(4, "Apple", "Apples", 1.00m);
            return new Products(new List<Product>() { beans, bread, milk, apples });
        }

        public static SpecialOffers GetAppleBeansBreadSpecialOffers(Products products)
        {
            // 10 % off apples
            SpecialOfferRule apples10percentOff = new SpecialOfferRule(new SpecialOfferMatchRule(products.GetProductByName("apple"), 1),
                   new SpecialOfferDiscountRule(products.GetProductByName("apple"), 10));

            // buy 2 cans of beans, get 1 loaf of bread 50% off
            SpecialOfferRule twoCans1BreadLoaf = new SpecialOfferRule(new SpecialOfferMatchRule(products.GetProductByName("beans"), 2),
                                new SpecialOfferDiscountRule(products.GetProductByName("bread"), 50, 1));
            SpecialOffers specialOffers = new SpecialOffers(new List<SpecialOfferRule>() { apples10percentOff, twoCans1BreadLoaf });
            return specialOffers;
        }

        public static Products GetProductsNoProducts()
        {
            return new Products(new List<Product>() { });
        }

        public static SpecialOffers GetNoSpecialOffers(Products products)
        {
            return new SpecialOffers(new List<SpecialOfferRule>() { });
        }

        public static Products GetProductSet2()
        {
            Product beans = new Product(1, "Beans", 0.65m);
            Product bread = new Product(2, "Bread", 0.80m);
            Product milk = new Product(3, "Milk", 1.30m);
            Product apples = new Product(4, "Apple", "Apples", 1.00m);
            return new Products(new List<Product>() { beans, bread, milk, apples });
        }

        public static SpecialOffers GetSpecialOffersSet2(Products products)
        {
            // 50% off beans when you buy 1 apple
            SpecialOfferRule apples10percentOff = new SpecialOfferRule(new SpecialOfferMatchRule(products.GetProductByName("apple"), 1),
                   new SpecialOfferDiscountRule(products.GetProductByName("Beans"), 50));
            // buy 2 cans of beans, get 1 loaf of bread 50% off
            SpecialOfferRule twoCans1BreadLoaf = new SpecialOfferRule(new SpecialOfferMatchRule(products.GetProductByName("beans"), 2),
                                new SpecialOfferDiscountRule(products.GetProductByName("bread"), 50, 1));
            SpecialOffers specialOffers = new SpecialOffers(new List<SpecialOfferRule>() { apples10percentOff, twoCans1BreadLoaf });
            return specialOffers;
        }
    }
}
