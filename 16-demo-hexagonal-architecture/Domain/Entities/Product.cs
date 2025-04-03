
namespace Domain.Entities
{
    public class Product
    {
        private string _name;
        private decimal _price;
        public Guid Id { get; set; }
        public string Name 
        { 
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("El nombre no puede ir vacío.");
                }
                _name = value;
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("El precio debe ser mayor a 0.");
                }
                _price = value;
            }
        }

        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
