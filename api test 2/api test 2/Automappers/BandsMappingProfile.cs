using api_test_2.DTOs;
using api_test_2.Models;
using AutoMapper;

namespace api_test_2.Mappers
{
    public class BandsMappingProfile : Profile
    {
        public BandsMappingProfile() 
        {
            CreateMap<Band, BandDto>();
            CreateMap<BandInsertDto, Band>();
            CreateMap<BandUpdateDto, Band>();
        }
    }
}
