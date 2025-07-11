using InfraKeep.Application.Mediator;
using MediatR;

namespace InfraKeep.Application.Devices.Commands
{
    public class CreateEquipmentTemplateCommand : ICommand<Unit>
    {
    }

    public class CreateEquipmentTemplateCommandHandler : ICommandHandler<CreateEquipmentTemplateCommand, Unit>
    {
        public Task<Unit> Handle(CreateEquipmentTemplateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
