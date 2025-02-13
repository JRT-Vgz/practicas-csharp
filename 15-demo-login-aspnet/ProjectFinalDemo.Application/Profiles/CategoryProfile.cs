using AutoMapper;
using ProjectFinalDemo.Application.Models.Categories;
using ProjectFinalDemo.Domain.Entities;

namespace ProjectFinalDemo.Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryEntity, CategoryResponseModel>()
                .ReverseMap();
            CreateMap<CategoryRequestModel, CategoryEntity>()
                .ReverseMap();
        }
    }
}
