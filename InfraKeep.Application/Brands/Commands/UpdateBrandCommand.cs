using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Brands;
using InfraKeep.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfraKeep.Application.Brands.Commands
{
    public class UpdateBrandCommand : ICommand<Unit>
    {
        public BrandDto Brand { get; set; }
    }

    public class UpdateBrandCommandHandler : ICommandHandler<UpdateBrandCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == request.Brand.Id, cancellationToken);

            if (brand == null) throw new Exception("Бренд не найден");

            _mapper.Map(request.Brand, brand);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}