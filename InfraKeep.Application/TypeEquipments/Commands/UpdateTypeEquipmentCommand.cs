using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.TypeEquipments;
using InfraKeep.Domain;
using InfraKeep.Domain.TypeEquipments;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfraKeep.Application.TypeEquipments.Commands
{
    public class UpdateTypeEquipmentCommand : ICommand<Unit>
    {
        public TypeEquipmentDto TypeEquipment { get; set; }
    }

    public class UpdateTypeEquipmentCommandHandler : ICommandHandler<UpdateTypeEquipmentCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTypeEquipmentCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTypeEquipmentCommand request, CancellationToken cancellationToken)
        {
            var typeEquipment = await _context.TypeEquipments.FirstOrDefaultAsync(x => x.Id == request.TypeEquipment.Id, cancellationToken);

            if (typeEquipment == null) throw new Exception("Тип технического средства не найден");

            _mapper.Map(request.TypeEquipment, typeEquipment);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
