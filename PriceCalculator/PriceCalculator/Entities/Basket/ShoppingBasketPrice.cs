using PriceCalculator.App.Entities.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.App.Entities.Basket
{
    public class ShoppingBasketPrice
    {
        public ShoppingBasketPrice(decimal subTotal, decimal total, List<SpecialOfferApplied> specialOfferApplieds)
        {
            Total = total;
            Subtotal = subTotal;
            SpecialOffersApplied = specialOfferApplieds;
        }

        public decimal Total { get; private set; }
        public decimal Subtotal { get; private set; }
        public List<SpecialOfferApplied> SpecialOffersApplied { get; private set; }
    }
}
