using InfraKeep.Application.Mediator;
using MediatR;
using System.Windows.Input;

namespace InfraKeep.Application.TechnicalEquipment.Commands
{
    public class CreateTechnicalEquipmentCommand : ICommand<Unit>
    {

    }

    public class CreateTechnicalEquipmentCommandHandler : ICommandHandler<CreateTechnicalEquipmentCommand, Unit>
    {
        public Task<Unit> Handle(CreateTechnicalEquipmentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
