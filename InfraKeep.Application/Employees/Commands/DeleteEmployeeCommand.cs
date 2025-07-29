using InfraKeep.Application.Mediator;
using InfraKeep.Domain;
using MediatR;

namespace InfraKeep.Application.Employees.Commands
{
    public class DeleteEmployeeCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteEmployeeCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _context.Employees.FindAsync(new object[] { request.Id }, cancellationToken);

            if (employee == null) throw new Exception("Сотрудник не найден!");

            _context.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
