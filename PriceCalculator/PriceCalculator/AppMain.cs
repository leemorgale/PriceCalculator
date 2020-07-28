using PriceCalculator.App.App;
using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.Basket;
using PriceCalculator.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.App
{
    public class AppMain : IAppMain
    {
        private readonly Products _products;
        private readonly SpecialOffers _specialOffers;
        public AppMain(Products products,
                   SpecialOffers specialOffers)
        {
            _products = products;
            _specialOffers = specialOffers;
        }
        public string Process(string[] args)
        {
            // read input from user
            IBasketInput shoppingBasketInput = new BasketInput();
            ShoppingBasket shoppingBasket = shoppingBasketInput.CreateShoppingBasketFromInput(args, _products);

            // calculate snopping basket price
            IBasketCalculator basketCalculator = new BasketCalculator(_specialOffers);
            CalculatedPrice shoppingBasketPrice = basketCalculator.CalculatePrice(shoppingBasket);

            // write output
            IBasketPriceOutput shoppingBacketConsoleOutput = new BasketPriceOutput();
            return shoppingBacketConsoleOutput.GetOutputString(shoppingBasketPrice);
        }
    }
}
