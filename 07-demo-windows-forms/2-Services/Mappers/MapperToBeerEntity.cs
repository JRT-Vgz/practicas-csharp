
using _1_Entities;
using _2_Services.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace _2_Services.Mappers
{
    public class MapperToBeerEntity : IMapper<BeerDTO, Beer>
    {
        public Beer Map(BeerDTO beerDto)
            => new Beer
            {
                Id = beerDto.Id,
                Name = beerDto.Name,
                BrandId = beerDto.BrandId,
                Alcohol = beerDto.Alcohol
            };
    }
}
