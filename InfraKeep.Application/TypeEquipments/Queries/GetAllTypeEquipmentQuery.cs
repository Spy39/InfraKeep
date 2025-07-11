using InfraKeep.Application.Mediator;
using MediatR;

namespace InfraKeep.Application.TypeEquipments.Queries
{
    public class GetAllTypeEquipmentQuery : IQuery<Unit>
    {

    }

    public class GetAllTypeEquipmentQueryHandler : IQueryHandler<GetAllTypeEquipmentQuery, Unit>
    {
        public Task<Unit> Handle(GetAllTypeEquipmentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
