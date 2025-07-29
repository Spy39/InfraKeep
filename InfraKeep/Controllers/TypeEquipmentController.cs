using InfraKeep.Application.Brands.Queries;
using InfraKeep.Application.Shared.TypeEquipments;
using InfraKeep.Application.TypeEquipments.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfraKeep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeEquipmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TypeEquipmentController(IMediator mediator)
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
        public async Task<IActionResult> Create([FromBody] TypeEquipmentDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) return BadRequest("Данные не переданы");

            var command = new CreateTypeEquipmentCommand { TypeEquipment = dto };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TypeEquipmentDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) return BadRequest("Данные не переданы");
            if (id != dto.Id) return BadRequest("ID в URL и теле запроса не совпадают");

            var command = new UpdateTypeEquipmentCommand { TypeEquipment = dto };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteTypeEquipmentCommand { Id = id };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

    }
}
