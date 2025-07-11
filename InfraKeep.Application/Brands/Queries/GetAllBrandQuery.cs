using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Brands;
using InfraKeep.Domain;
using Microsoft.EntityFrameworkCore;

namespace InfraKeep.Application.Brands.Queries
{
    public class GetAllBrandQuery : IQuery<List<BrandDto>> { }

    public class GetAllBrandQueryHandler : IQueryHandler<GetAllBrandQuery, List<BrandDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllBrandQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BrandDto>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            var brands = await _context.Brands.ToListAsync(cancellationToken);
            return _mapper.Map<List<BrandDto>>(brands);
        }
    }
}