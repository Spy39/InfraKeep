using InfraKeep.Application.Mediator;
using InfraKeep.Domain;
using MediatR;

namespace InfraKeep.Application.Brands.Commands
{
    public class DeleteBrandCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteBrandCommandHandler : ICommandHandler<DeleteBrandCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteBrandCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _context.Brands.FindAsync(new object[] { request.Id }, cancellationToken);

            if (brand == null) throw new Exception("Бренд не найден!");

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
