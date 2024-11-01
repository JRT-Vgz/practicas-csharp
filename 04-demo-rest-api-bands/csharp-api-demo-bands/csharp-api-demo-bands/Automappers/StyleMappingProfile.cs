using AutoMapper;
using csharp_api_demo_bands.DTOs;
using csharp_api_demo_bands.Models;

namespace csharp_api_demo_bands.Automappers
{
    public class StyleMappingProfile : Profile
    {
        public StyleMappingProfile() 
        {
            CreateMap<Style, StyleDto>();
            CreateMap<StyleInsertDto, Style>();
            CreateMap<StyleUpdateDto, Style>();
        }
    }
}
