
namespace _1_Entities
{
    public class Concept
    {
        public int Quantity { get; }
        public int IdBeer { get; }
        public decimal UnitPrice { get; }
        public decimal Price { get; }

        public Concept(int quantity, int idBeer, decimal unitPrice)
        {
            Quantity = quantity;
            IdBeer = idBeer;
            UnitPrice = unitPrice;
            Price = GetTotalPrice();
        }

        private decimal GetTotalPrice()
            => Quantity * UnitPrice;
    }
}
