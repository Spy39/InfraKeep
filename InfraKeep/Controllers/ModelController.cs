using InfraKeep.Application.Brands.Queries;
using InfraKeep.Application.Models.Commands;
using InfraKeep.Application.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfraKeep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ModelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var query = new GetAllBrandQuery();
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ModelDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) return BadRequest("Данные не переданы");

            var command = new CreateModelCommand{ Model = dto};
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody]ModelDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) return BadRequest("Данные не переданы");
            if (id != dto.Id) return BadRequest("ID в URL и теле запроса не совпадают");

            var command = new UpdateModelCommand { Model = dto };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteModelCommand { Id = id };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

    }
}
