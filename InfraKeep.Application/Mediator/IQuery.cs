using MediatR;

namespace InfraKeep.Application.Mediator
{
    internal interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
