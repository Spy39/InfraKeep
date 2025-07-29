using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Employees;
using InfraKeep.Domain;
using Microsoft.EntityFrameworkCore;

namespace InfraKeep.Application.Employees.Queries
{
    public class GetAllEmployeeQuery : IQuery<List<EmployeeDto>> { }

    public class GetAllEmployeeQueryHandler : IQueryHandler<GetAllEmployeeQuery, List<EmployeeDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllEmployeeQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.ToListAsync(cancellationToken);
            return _mapper.Map<List<EmployeeDto>>(employee);
        }
    }
}
