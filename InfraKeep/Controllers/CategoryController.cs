using InfraKeep.Application.Categories.Commands;
using InfraKeep.Application.Categories.Queries;
using InfraKeep.Application.Shared.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfraKeep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var query = new GetAllCategoryQuery();
            var result = _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) return BadRequest("Данные не переданы");

            var command = new CreateCategoryCommand { Category = dto };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) return BadRequest("Данные не переданы");
            if (id != dto.Id) return BadRequest("ID в URL и теле запроса не совпадают");

            var command = new UpdateCategoryCommand { Category = dto };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

    }
}
