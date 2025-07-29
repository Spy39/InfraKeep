using AutoMapper;
using InfraKeep.Application.Shared.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InfraKeep.Application.Models.Mapping
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<ModelDto, Model>();
            CreateMap<Model, ModelDto>();
        }
    }
}
