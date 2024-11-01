using AutoMapper;
using csharp_api_demo_bands.DTOs;
using csharp_api_demo_bands.Models;

namespace csharp_api_demo_bands.Automappers
{
    public class BandMappingProfile : Profile
    {
        public BandMappingProfile()
        {
            CreateMap<Band, BandDto>()
                .ForMember(dest => dest.BandID, map => map.MapFrom(org => org.Id));
            CreateMap<BandInsertDto, Band>();
            CreateMap<BandUpdateDto, Band>();
        }
    }
}
