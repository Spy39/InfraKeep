using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Locations;
using InfraKeep.Domain;
using InfraKeep.Domain.Locations;
using MediatR;
using System.Windows.Input;

namespace InfraKeep.Application.Locations.Commands
{
    public class CreateLocationCommand : ICommand<Unit>
    {
        public LocationDto Location { get; set; }
    }

    public class CreateLocationCommandHandler : ICommandHandler<CreateLocationCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateLocationCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = _mapper.Map<Location>(cancellationToken);

            await _context.AddAsync(location, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
