using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Employees;
using InfraKeep.Domain;
using InfraKeep.Domain.Employees;
using MediatR;

namespace InfraKeep.Application.Employees.Commands
{
    public class CreateEmployeeCommand : ICommand<Unit>
    {
        public EmployeeDto Employee { get; set; }
    }

    public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request.Employee);

            await _context.Employees.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
