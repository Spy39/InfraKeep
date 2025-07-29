using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Locations;
using InfraKeep.Domain;
using Microsoft.EntityFrameworkCore;

namespace InfraKeep.Application.Locations.Queries
{
    public class GetAllLocationQuery : IQuery<List<LocationDto>> { }

    public class GetAllLocationQueryHandler : IQueryHandler<GetAllLocationQuery, List<LocationDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllLocationQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LocationDto>> Handle(GetAllLocationQuery request, CancellationToken cancellationToken)
        {
            var locations = await _context.Locations.ToListAsync(cancellationToken);
            return _mapper.Map<List<LocationDto>>(locations);
        }
    }
}
