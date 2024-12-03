
using _1_Entities;
using _2_Services;
using _2_Services.DTOs;
using _3_Repositories.AdditionalDataClass;

namespace _3_Repositories.Mappers
{
    public class SuperMapperToBeerDTO : ISuperMapper<Beer, BeerAdditionalData, BeerDTO>
    {
        public BeerDTO Map(Beer beer, BeerAdditionalData beerAdditionalData)
        {
            return new BeerDTO
            {
                Id = beer.Id,
                Name = beer.Name,
                BrandId = beer.BrandId,
                Alcohol = beer.Alcohol,
                Description = beerAdditionalData.Description
            };
        }
    }
}
