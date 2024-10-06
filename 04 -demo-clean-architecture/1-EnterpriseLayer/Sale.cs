using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _1_EnterpriseLayer
{
    public class Sale
    {
        public int Id { get; }
        public DateTime Date { get; }
        public decimal Total { get; }
        public List<Concept> Concepts { get; }

        public Sale(DateTime date, List<Concept> concepts)
        {
            Date = date;
            Concepts = concepts;
            Total = GetTotal();
        }

        public Sale(int id, DateTime date, List<Concept> concepts) 
        {
            Id = id;
            Date = date;
            Concepts = concepts;
            Total = GetTotal();
        }
        private decimal GetTotal()
            => Concepts.Sum(c => c.Price);
    }
}
