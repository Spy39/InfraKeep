using MediatR;

namespace InfraKeep.Application.Mediator
{
    internal interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
