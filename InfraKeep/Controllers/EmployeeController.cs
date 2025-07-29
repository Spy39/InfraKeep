using InfraKeep.Application.Employees.Commands;
using InfraKeep.Application.Employees.Queries;
using InfraKeep.Application.Shared.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfraKeep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var query = new GetAllEmployeeQuery();
            var result = _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) return BadRequest("Данные не переданы");

            var command = new CreateEmployeeCommand { Employee = dto };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeDto dto, CancellationToken cancellationToken = default)
        {
            if (dto == null) return BadRequest("Данные не переданы");
            if (id != dto.Id) return BadRequest("ID в URL и теле запроса не совпадают");

            var command = new UpdateEmployeeCommand { Employee = dto };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

    }
}
