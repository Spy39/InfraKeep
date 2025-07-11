using InfraKeep.Application.Mediator;
using InfraKeep.Domain;
using MediatR;

namespace InfraKeep.Application.Models.Commands
{
    public class CreateModelCommand : ICommand<Unit>
    {
    }

    public class CreateModelCommandHandler : ICommandHandler<CreateModelCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        public CreateModelCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
