using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_InterfaceAdapters_Mappers.Dtos.Requests
{
    public class SaleRequestDto
    {
        public List<ConceptRequestDto> Concepts { get; set; }
    }

    public class ConceptRequestDto
    {
        public int IdBeer { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
