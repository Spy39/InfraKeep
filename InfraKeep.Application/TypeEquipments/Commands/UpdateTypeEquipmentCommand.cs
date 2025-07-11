using InfraKeep.Application.Mediator;
using MediatR;

namespace InfraKeep.Application.TypeEquipments.Commands
{
    public class UpdateTypeEquipmentCommand : ICommand<Unit>
    {

    }

    public class UpdateTypeEquipmentCommandHandler : ICommandHandler<UpdateTypeEquipmentCommand, Unit>
    {
        public Task<Unit> Handle(UpdateTypeEquipmentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
