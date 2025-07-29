using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Models;
using InfraKeep.Domain;
using Microsoft.EntityFrameworkCore;

namespace InfraKeep.Application.Models.Queries
{
    public class GetAllModelQuery : IQuery<List<ModelDto>> { }

    public class GetAllModelQueryHandler : IQueryHandler<GetAllModelQuery, List<ModelDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllModelQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ModelDto>> Handle(GetAllModelQuery request, CancellationToken cancellationToken)
        {
            var models = await _context.Models.ToListAsync(cancellationToken);
            return _mapper.Map<List<ModelDto>>(models);
        }
    }
}
