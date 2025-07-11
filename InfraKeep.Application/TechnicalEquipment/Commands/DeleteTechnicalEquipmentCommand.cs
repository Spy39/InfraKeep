using InfraKeep.Application.Mediator;
using MediatR;

namespace InfraKeep.Application.TechnicalEquipment.Commands
{
    public class DeleteTechnicalEquipmentCommand : ICommand<Unit>
    {
    }

    public class DeleteTechnicalEquipmentCommandHandler : ICommandHandler<DeleteTechnicalEquipmentCommand, Unit>
    {
        public Task<Unit> Handle(DeleteTechnicalEquipmentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
