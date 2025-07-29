using InfraKeep.Application.Mediator;
using InfraKeep.Domain;
using MediatR;

namespace InfraKeep.Application.TypeEquipments.Commands
{
    public class DeleteTypeEquipmentCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteTypeEquipmentCommandHandler : ICommandHandler<DeleteTypeEquipmentCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteTypeEquipmentCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTypeEquipmentCommand request, CancellationToken cancellationToken)
        {
            var typeEquipment = await _context.TypeEquipments.FindAsync(new object[] { request.Id }, cancellationToken);

            if (typeEquipment == null) throw new Exception("Тип технического средства не найден!");

            _context.TypeEquipments.Remove(typeEquipment);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
