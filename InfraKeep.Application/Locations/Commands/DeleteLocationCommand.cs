using InfraKeep.Application.Mediator;
using InfraKeep.Domain;
using MediatR;

namespace InfraKeep.Application.Locations.Commands
{
    public class DeleteLocationCommand : ICommand<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteLocationCommandHandler : ICommandHandler<DeleteLocationCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteLocationCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _context.Locations.FindAsync(new object[] { request.Id }, cancellationToken);

            if (location == null) throw new Exception("Местоположение не найдено");

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
