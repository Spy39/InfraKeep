using AutoMapper;
using InfraKeep.Application.Shared.Brands;
using InfraKeep.Domain.Brands;

namespace InfraKeep.Application.Brands.Mapping
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandDto, Brand>();
            CreateMap<Brand, BrandDto>();
        }
    }
}