using InfraKeep.Application.Mediator;
using MediatR;

namespace InfraKeep.Application.TechnicalEquipment.Commands
{
    public class UpdateTechnicalEquipmentCommand : ICommand<Unit>
    {
    }

    public class UpdateTechnicalEquipmentCommandHandler : ICommandHandler<UpdateTechnicalEquipmentCommand, Unit>
    {
        public Task<Unit> Handle(UpdateTechnicalEquipmentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
