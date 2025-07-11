using MediatR;

namespace InfraKeep.Application.Mediator
{
    internal interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IQuery<TResponse>
    {
    }
}
