using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Models;
using InfraKeep.Domain;
using InfraKeep.Domain.Models;
using MediatR;

namespace InfraKeep.Application.Models.Commands
{
    public class CreateModelCommand : ICommand<Unit>
    {
        public ModelDto Model { get; set; }
    }

    public class CreateModelCommandHandler : ICommandHandler<CreateModelCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateModelCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Model>(request.Model);

            await _context.Models.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
