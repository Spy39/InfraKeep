using MediatR;

namespace InfraKeep.Application.Mediator
{
    internal interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
    }
}
