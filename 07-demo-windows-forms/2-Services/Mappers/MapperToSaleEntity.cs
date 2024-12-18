
using _1_Entities;
using _2_Services.DTOs;

namespace _2_Services.Mappers
{
    public class MapperToSaleEntity : IMapper<SaleDTO, Sale>
    {
        public Sale Map(SaleDTO saleDTO)
        {
            var concepts = new List<Concept>();

            foreach (var conceptDTO in saleDTO.Concepts)
            {
                concepts.Add(new Concept(conceptDTO.Quantity, conceptDTO.IdBeer, conceptDTO.UnitPrice));
            }

            return new Sale(DateTime.Now, concepts);
        }
    }
}
