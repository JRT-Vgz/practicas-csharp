using AutoMapper;
using Test_api_3.DTOs;
using Test_api_3.Models;

namespace Test_api_3.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Band, BandDto>();
        }
    }
}
