using AutoMapper;
using InfraKeep.Application.Mediator;
using InfraKeep.Application.Shared.Models;
using InfraKeep.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfraKeep.Application.Models.Commands
{
    public class UpdateModelCommand : ICommand<Unit>
    {
        public ModelDto Model { get; set; }
    }

    public class UpdateModelCommandHandler : ICommandHandler<UpdateModelCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateModelCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var model = await _context.Models.FirstOrDefaultAsync(x => x.Id == request.Model.Id, cancellationToken);

            if(model == null) throw new Exception("Модель не найдена");

            _mapper.Map(request.Model ,model);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
