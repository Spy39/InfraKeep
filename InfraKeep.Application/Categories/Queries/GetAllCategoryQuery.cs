using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Categories;
using InfraKeep.Domain;
using Microsoft.EntityFrameworkCore;

namespace InfraKeep.Application.Categories.Queries
{
    public class GetAllCategoryQuery : IQuery<List<CategoryDto>> { }

    public class GetAllCategoryQueryHandler : IQueryHandler<GetAllCategoryQuery, List<CategoryDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.ToListAsync(cancellationToken);
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
