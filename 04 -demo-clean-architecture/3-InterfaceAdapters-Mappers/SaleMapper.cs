using _1_EnterpriseLayer;
using _2_ApplicationLayer;
using _3_InterfaceAdapters_Mappers.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_InterfaceAdapters_Mappers
{
    public class SaleMapper : IMapper<SaleRequestDto, Sale>
    {
        public Sale Map(SaleRequestDto saleDto)
        {
            var concepts = new List<Concept>();
            foreach (var conceptDto in saleDto.Concepts) 
            {
                concepts.Add(new Concept(conceptDto.IdBeer, conceptDto.Quantity, conceptDto.UnitPrice));
            }

            return new Sale(DateTime.Now, concepts);
        }
    }
}
