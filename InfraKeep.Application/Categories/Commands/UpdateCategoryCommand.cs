using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Categories;
using InfraKeep.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfraKeep.Application.Categories.Commands
{
    public class UpdateCategoryCommand : ICommand<Unit>
    {
        public CategoryDto Category { get; set; }
    }

    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Category.Id, cancellationToken);

            if (category == null) throw new Exception("Категория не найдена!");

            _mapper.Map(request.Category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
