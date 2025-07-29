using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.TypeEquipments;
using InfraKeep.Domain;
using InfraKeep.Domain.TypeEquipments;
using MediatR;

namespace InfraKeep.Application.TypeEquipments.Commands
{
    public class CreateTypeEquipmentCommand : ICommand<Unit>
    {
        public TypeEquipmentDto TypeEquipment { get; set; }
    }

    public class CreateTypeEquipmentCommandHandler : ICommandHandler<CreateTypeEquipmentCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateTypeEquipmentCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateTypeEquipmentCommand request, CancellationToken cancellationToken)
        {
            var typeEquipment = _mapper.Map<TypeEquipment>(request.TypeEquipment);

            await _context.TypeEquipments.AddAsync(typeEquipment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
