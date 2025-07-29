using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.TypeEquipments;
using InfraKeep.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfraKeep.Application.TypeEquipments.Queries
{
    public class GetAllTypeEquipmentQuery : IQuery<List<TypeEquipmentDto>> { }

    public class GetAllTypeEquipmentQueryHandler : IQueryHandler<GetAllTypeEquipmentQuery, List<TypeEquipmentDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllTypeEquipmentQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TypeEquipmentDto>> Handle(GetAllTypeEquipmentQuery request, CancellationToken cancellationToken)
        {
            var typeEquipments = await _context.TypeEquipments.ToListAsync(cancellationToken);
            return _mapper.Map<List<TypeEquipmentDto>>(typeEquipments);
        }
    }
}
