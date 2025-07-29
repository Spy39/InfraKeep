using AutoMapper;
using InfraKeep.Application.Shared.Categories;
using InfraKeep.Domain.Categories;

namespace InfraKeep.Application.Categories.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
