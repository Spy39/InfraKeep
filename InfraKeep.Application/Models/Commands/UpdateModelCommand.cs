using InfraKeep.Application.Mediator;
using MediatR;

namespace InfraKeep.Application.Models.Commands
{
    public class UpdateModelCommand : ICommand<Unit>
    {
    }

    public class UpdateModelCommandHandler : ICommandHandler<UpdateModelCommand, Unit>
    {
        public Task<Unit> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
