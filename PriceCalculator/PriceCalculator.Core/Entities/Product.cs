using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Core.Entities
{
    public class Product
    {
        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }
}
