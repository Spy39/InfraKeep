using InfraKeep.Application.Mediator;
using InfraKeep.Domain;
using MediatR;

namespace InfraKeep.Application.Models.Commands
{
    public class DeleteModelCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteModelCommandHandler : ICommandHandler<DeleteModelCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteModelCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            var model = await _context.Models.FindAsync(new object[] { request.Id }, cancellationToken);

            if (model == null) throw new Exception("Модель не найдена");

            _context.Remove(model);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
