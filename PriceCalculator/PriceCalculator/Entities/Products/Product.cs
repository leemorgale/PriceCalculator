namespace PriceCalculator.App.Entities.Products
{
    public class Product
    {
        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = name;
        }
        public Product(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
    }
}
