using InfraKeep.Application.Mediator;
using MediatR;

namespace InfraKeep.Application.TypeEquipments.Commands
{
    public class DeleteTypeEquipmentCommand : ICommand<Unit>
    {
    }

    public class DeleteTypeEquipmentCommandHandler : ICommandHandler<DeleteTypeEquipmentCommand, Unit>
    {
        public Task<Unit> Handle(DeleteTypeEquipmentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
