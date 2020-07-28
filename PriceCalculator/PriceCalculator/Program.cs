using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.SpecialOffers;
using System;
using System.Collections.Generic;
using PriceCalculator.App.Interfaces;
using PriceCalculator.App.Entities.Products;

namespace PriceCalculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create Product List for example in paper
                ProductsDL productsDL = new ProductsDL(new List<Product>() { 
                    new Product(1, "Beans", 0.65m),
                    new Product(2, "Bread", 0.80m), 
                    new Product(3, "Milk", 1.30m),
                    new Product(4, "Apple", "Apples", 1.00m) 
                });

                // create special offers
                // Offer 1: 10% off apples
                SpecialOfferRule apples10percentOff = new SpecialOfferRule(
                    new SpecialOfferMatchRule(productsDL.GetProductByName("apple"), 1),
                    new SpecialOfferDiscountRule(productsDL.GetProductByName("apple"), 10));

                // Offer 2: Buy 2 cans of beans get 1 loaf of bread 50 percent off
                SpecialOfferRule twoCans1BreadLoaf = new SpecialOfferRule(
                    new SpecialOfferMatchRule(productsDL.GetProductByName("beans"), 2),
                    new SpecialOfferDiscountRule(productsDL.GetProductByName("bread"), 50, 1));
                SpecialOffersDL specialOffers = new SpecialOffersDL(new List<SpecialOfferRule>() { apples10percentOff, twoCans1BreadLoaf });

                // process user imput with products and special offers
                IAppMain appMain = new AppMain(productsDL, specialOffers);
                string output = appMain.Process(args);
                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                // log out error not just to console.
                Console.WriteLine("Fatal Error occured: ", ex);
            }
        }
    }
}
