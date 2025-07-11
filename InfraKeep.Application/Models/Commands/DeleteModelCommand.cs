using InfraKeep.Application.Mediator;
using MediatR;

namespace InfraKeep.Application.Models.Commands
{
    public class DeleteModelCommand : ICommand<Unit>
    {
    }

    public class DeleteModelCommandHandler : ICommandHandler<DeleteModelCommand, Unit>
    {
        public Task<Unit> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
