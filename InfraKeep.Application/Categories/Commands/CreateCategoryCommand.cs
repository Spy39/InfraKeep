using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Categories;
using InfraKeep.Domain;
using InfraKeep.Domain.Categories;
using MediatR;

namespace InfraKeep.Application.Categories.Commands
{
    public class CreateCategoryCommand : ICommand<Unit>
    {
        public CategoryDto Category { get; set; }
    }

    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.Category);

            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
