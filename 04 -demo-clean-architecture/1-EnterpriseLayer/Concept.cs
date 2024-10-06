using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_EnterpriseLayer
{
    public class Concept
    {
        public int IdBeer { get; set; }
        public int Quantity {  get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }

        public Concept(int idBeer, int quantity, decimal unitPrice)
        {
            IdBeer = idBeer;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Price = GetTotalPrice();
        }

        private decimal GetTotalPrice()
            => Quantity * UnitPrice;
    }
}
