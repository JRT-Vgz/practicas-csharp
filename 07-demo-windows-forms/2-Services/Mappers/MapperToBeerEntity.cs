
using _1_Entities;
using _2_Services.DTOs;

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
                Alcohol = beerDto.Alcohol,
                Price = beerDto.Price
            };
    }
}
