using AutoMapper;
using InfraKeep.Application.Shared.Locations;
using InfraKeep.Domain.Locations;

namespace InfraKeep.Application.Locations.Mapping
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationDto, Location>();
            CreateMap<Location, LocationDto>();
        }
    }
}
