using InfraKeep.Application.Mediator;
using InfraKeep.Domain;
using MediatR;

namespace InfraKeep.Application.Categories.Commands
{
    public class DeleteCategoryCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteCategoryCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.FindAsync(new object[] { request.Id }, cancellationToken);

            if (category == null) throw new Exception("Категория не найдена!");

            _context.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
