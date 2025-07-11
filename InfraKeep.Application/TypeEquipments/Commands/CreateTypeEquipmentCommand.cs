using InfraKeep.Application.Mediator;
using MediatR;

namespace InfraKeep.Application.TypeEquipments.Commands
{
    public class CreateTypeEquipmentCommand : ICommand<Unit>
    {
    }

    public class CreateTypeEquipmentCommandHandler : ICommandHandler<CreateTypeEquipmentCommand, Unit>
    {
        public Task<Unit> Handle(CreateTypeEquipmentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
