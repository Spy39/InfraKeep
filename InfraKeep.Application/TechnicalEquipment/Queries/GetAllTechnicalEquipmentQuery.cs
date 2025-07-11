using InfraKeep.Application.Mediator;
using MediatR;

namespace InfraKeep.Application.TechnicalEquipment.Queries
{
    public class GetAllTechnicalEquipmentQuery : IQuery<Unit>
    {
    }

    public class GetAllTechnicalEquipmentQueryHandler : IQueryHandler<GetAllTechnicalEquipmentQuery, Unit>
    {
        public Task<Unit> Handle(GetAllTechnicalEquipmentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
