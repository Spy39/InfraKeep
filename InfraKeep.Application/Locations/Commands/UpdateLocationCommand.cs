using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Locations;
using InfraKeep.Domain;
using InfraKeep.Domain.Brands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfraKeep.Application.Locations.Commands
{
    public class UpdateLocationCommand : ICommand<Unit>
    {
        public LocationDto Location { get; set; }
    }

    public class UpdateLocationCommandHandler : ICommandHandler<UpdateLocationCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateLocationCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(x => x.Id == request.Location.Id, cancellationToken);

            if (location == null) throw new Exception("Местоположение не найдено");

            _mapper.Map(request.Location, location);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
