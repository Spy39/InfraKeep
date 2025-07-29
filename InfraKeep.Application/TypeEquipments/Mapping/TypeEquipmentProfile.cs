using AutoMapper;
using InfraKeep.Application.Shared.TypeEquipments;
using InfraKeep.Domain.TypeEquipments;

namespace InfraKeep.Application.TypeEquipments.Mapping
{
    public class TypeEquipmentProfile : Profile
    {
        public TypeEquipmentProfile()
        {
            CreateMap<TypeEquipmentDto, TypeEquipment>();
            CreateMap<TypeEquipment, TypeEquipmentDto>();
        }
    }
}
