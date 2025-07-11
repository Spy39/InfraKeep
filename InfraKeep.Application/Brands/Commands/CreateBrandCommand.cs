using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Brands;
using InfraKeep.Domain;
using InfraKeep.Domain.Brands;
using MediatR;

namespace InfraKeep.Application.Brands.Commands
{
    public class CreateBrandCommand : ICommand<Unit>
    {
        public BrandDto Brand { get; set; }

    }

    public class CreateBrandCommandHandler : ICommandHandler<CreateBrandCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request.Brand);

            await _context.Brands.AddAsync(brand, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
