using InfraKeep.Application.Mediator;
using MediatR;

namespace InfraKeep.Application.Models.Queries
{
    public class GetAllModelQuery : IQuery<Unit>
    {
    }

    public class GetAllModelQueryHandler : IQueryHandler<GetAllModelQuery, Unit>
    {
        public Task<Unit> Handle(GetAllModelQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
