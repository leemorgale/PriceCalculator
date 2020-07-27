using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculator.App.Entities.Basket
{
    public class ShoppingBasket
    {
        private readonly List<Product.Product> _products = new List<Product.Product>();

        public void AddItem(Product.Product product)
        {
            _products.Add(product);
        }

        public int GetItemCountById(int id)
        {
            return _products.Where(p => p.Id == id).Count();
        }

        public decimal GetBasketPrice()
        {
            decimal sum = 0;
            _products.ForEach(item => sum += item.Price);
            return sum;
        }
    }
}
