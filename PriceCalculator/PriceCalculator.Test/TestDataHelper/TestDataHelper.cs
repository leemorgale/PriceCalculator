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

        public static Products EmptyProducts()
        {
            return new Products(new List<Product>() { });
        }

        public static SpecialOffers EmptySpecialOffers(Products products)
        {
            return new SpecialOffers(new List<SpecialOfferRule>() { });
        }

        public static Products GetProductBeansStrawberriesMilkApplesOranges()
        {
            Product beans = new Product(1, "Beans", 0.65m);
            Product strawberries = new Product(2, "Strawberries", 0.80m);
            Product milk = new Product(3, "Milk", 1.30m);
            Product apples = new Product(4, "Apple", "Apples", 1.00m);
            Product oranges = new Product(5, "Oranges", 1.20m);
            return new Products(new List<Product>() { beans, strawberries, milk, apples, oranges });
        }

        public static SpecialOffers GetSpecialOffers3oranges1applefree(Products products)
        {
            // buy 90 % off strawberries
            SpecialOfferRule apples10percentOff = new SpecialOfferRule(
                    new SpecialOfferMatchRule(products.GetProductByName("Strawberries"), 1),
                    new SpecialOfferDiscountRule(products.GetProductByName("Strawberries"), 90));
            
            // buy 3 oranges, get 1 apple for free
            SpecialOfferRule threeOrangesOneAppleFree = new SpecialOfferRule(
                   new SpecialOfferMatchRule(products.GetProductByName("oranges"), 3),
                   new SpecialOfferDiscountRule(products.GetProductByName("apple"), 100, 1));

            SpecialOffers specialOffers = new SpecialOffers(new List<SpecialOfferRule>() { apples10percentOff, threeOrangesOneAppleFree });
            return specialOffers;
        }
    }
}
