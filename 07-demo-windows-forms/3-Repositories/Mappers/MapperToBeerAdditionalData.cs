
using _2_Services;
using _2_Services.DTOs;
using _3_Repositories.AdditionalDataClass;

namespace _3_Repositories.Mappers
{
    public class MapperToBeerAdditionalData : IMapper<BeerDTO, BeerAdditionalData>
    {
        public BeerAdditionalData Map(BeerDTO beerDto)
            => new BeerAdditionalData { Description = beerDto.Description };
    }
}
