namespace SmallStore.Core.Models
{
    public class Product
    {
        public const int MAX_NAME_LENGTH = 200;

        private Product(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }

        public static (Product Product, string Error) Create(Guid id, string name, string description, decimal price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = "Name is empty or too long";
            }

            var product = new Product(id, name, description, price);

            return (product, error);
        }
    }
}
