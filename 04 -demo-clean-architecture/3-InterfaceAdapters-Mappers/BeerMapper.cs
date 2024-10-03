using _1_EnterpriseLayer;
using _2_ApplicationLayer;
using _3_InterfaceAdapters_Mappers.Dtos.Requests;

namespace _3_InterfaceAdapters_Mappers
{
    public class BeerMapper : IMapper<BeerRequestDto, Beer>
    {
        public Beer Map(BeerRequestDto dto) 
            => new Beer
            {
                Id = dto.Id,
                Name = dto.Name,
                Style = dto.Style,
                Alcohol = dto.Alcohol
            };
    }
}
