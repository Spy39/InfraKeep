using InfraKeep.Application.Mediator;
using MediatR;

namespace InfraKeep.Application.Devices.Queries
{
    public class GetAllEquipmentTemplateQuery : IQuery<Unit>
    {
    }

    public class GetAllEquipmentTemplateQueryHandler : IQueryHandler<GetAllEquipmentTemplateQuery, Unit>
    {
        public Task<Unit> Handle(GetAllEquipmentTemplateQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}