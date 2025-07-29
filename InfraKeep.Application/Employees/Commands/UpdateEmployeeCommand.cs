using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Employees;
using InfraKeep.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace InfraKeep.Application.Employees.Commands
{
    public class UpdateEmployeeCommand : ICommand<Unit>
    {
        public EmployeeDto Employee { get; set; }
    }

    public class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _context.Employees.FirstOrDefaultAsync(x => x.Id == request.Employee.Id, cancellationToken);

            if (employee == null) throw new Exception("Сотрудник не найден!");

            _mapper.Map(request.Employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
