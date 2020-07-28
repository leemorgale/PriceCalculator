using Microsoft.Extensions.DependencyInjection;
using PriceCalculator.App.App;
using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.Basket;
using PriceCalculator.App.Entities.Product;
using PriceCalculator.App.Entities.SpecialOffers;
using PriceCalculator.App.App;
using System;
using System.Collections.Generic;
using PriceCalculator.App.Interfaces;

namespace PriceCalculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create Product List for example in paper
                Products products = new Products(new List<Product>() { 
                    new Product(1, "Beans", 0.65m),
                    new Product(2, "Bread", 0.80m), 
                    new Product(3, "Milk", 1.30m),
                    new Product(4, "Apple", "Apples", 1.00m) 
                });

                // create special offers
                // Offer 1: 10% off apples
                SpecialOfferRule apples10percentOff = new SpecialOfferRule(
                    new SpecialOfferMatchRule(products.GetProductByName("apple"), 1),
                    new SpecialOfferDiscountRule(products.GetProductByName("apple"), 10));
                // Offer 2: Buy 2 cans of beans get 1 loaf of bread 50 percent off
                SpecialOfferRule twoCans1BreadLoaf = new SpecialOfferRule(
                    new SpecialOfferMatchRule(products.GetProductByName("beans"), 2),
                    new SpecialOfferDiscountRule(products.GetProductByName("bread"), 50, 1));
                SpecialOffers specialOffers = new SpecialOffers(new List<SpecialOfferRule>() { apples10percentOff, twoCans1BreadLoaf });

                // process user imput with products and special offers
                IAppMain appMain = new AppMain(products, specialOffers);
                var output = appMain.Process(args);
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
