using AutoMapper;
using Test_API_1.DTOs;
using Test_API_1.Models;

namespace Test_API_1.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<BandInsertDto, Band>();
            CreateMap<BandUpdateDto, Band>();
            CreateMap<Band, BandDto>();
        }
    }
}
