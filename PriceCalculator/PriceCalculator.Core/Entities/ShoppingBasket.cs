using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Core.Entities
{
    public class ShoppingBasket
    {
        public ShoppingBasket()
        {
            Basket = new List<ProductQuantity>();
        }

        public List<ProductQuantity> Basket { get; set; }


    }
}
