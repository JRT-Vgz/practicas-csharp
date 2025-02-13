using AutoMapper;
using ProjectFinalDemo.Application.Models.Products;
using ProjectFinalDemo.Domain.Entities;

namespace ProjectFinalDemo.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductResponseModel>()                
                .ReverseMap();
            CreateMap<ProductRequestModel, ProductEntity>().ReverseMap();
        }
    }
}
