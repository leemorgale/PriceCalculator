using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Core.Entities
{
    public class ProductQuantity
    {
        public ProductQuantity(Product product, int quantity = 1)
        {
            Product = product;
            Quantity = quantity;
        }
        public Product Product { get; private set; }

        public int Quantity { get; private set; }
    }
}
