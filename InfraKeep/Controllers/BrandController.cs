using InfraKeep.Application.Brands.Commands;
using InfraKeep.Application.Brands.Queries;
using InfraKeep.Application.Shared.Brands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfraKeep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        public readonly IMediator _mediator;
        public BrandController(IMediator mediator)
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

        [HttpGet("[action]")]
        public async Task<ActionResult<List<BrandDto>>> GetAll2(CancellationToken cancellationToken = default)
        {
            var query = new GetAllBrandQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BrandDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) return BadRequest("Данные не переданы");

            var command = new CreateBrandCommand { Brand = dto };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] BrandDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) return BadRequest("Данные не переданы");
            if (id != dto.Id) return BadRequest("ID в URL и теле запроса не совпадают");

            var command = new UpdateBrandCommand { Brand = dto };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteBrandCommand { Id = id };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}