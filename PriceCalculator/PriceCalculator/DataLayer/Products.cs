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

        public Product GetProductByName(string name)
        {
            if(_products == null)
            {
                return null;
            }
            return  _products.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }
    }
}
