using PriceCalculator.App.Entities.Product;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator.App.DataLayer
{
    public class Products
    {
        private List<Product> _products;
        public Products(List<Product> products)
        {
            _products = products;
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product GetProductByName(string name)
        {
            return _products.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }
    }
}
