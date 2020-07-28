using PriceCalculator.App.Entities.Products;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator.App.DataLayer
{
    public class ProductsDL
    {
        private List<Product> _products;
        public ProductsDL(List<Product> products)
        {
            _products = products;
        }

        public Product GetProductByName(string name)
        {
            if(_products == null)
            {
                return null;
            }
            return _products.FirstOrDefault(p => p.Name.ToLower() == name.ToLower()
                                                 || p.Description.ToLower() == name.ToLower());
        }
    }
}
