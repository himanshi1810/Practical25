using Employee.DAL.Handlers.Commands;
using Employee.DAL.Handlers.Queries;
using Employee.DAL.Models.DTOs;
using Employee.DAL.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILoggerService _logger;
        public EmployeeController(IMediator mediator,ILoggerService logger )
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees(int? id = null)
        {
            var result = await _mediator.Send(new GetEmployee(id));
            _logger.Log($"CEmployee Fetched Successfully");
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEmployeeDTO emp)
        {
            await _mediator.Send(new AddEmployeeCommand(emp));
            _logger.Log($"Created employee {emp.EmployeeName}");
            return Ok($"Employee {emp.EmployeeName} added");
        }

        [HttpPut]
        public IActionResult Update(UpdateEmployeeDTO emp)
        {
            _mediator.Send(new UpdateEmployeeCommand(emp));
            _logger.Log($"Updated employee {emp.EmployeeName}");
            return Ok($"Employee {emp.EmployeeName} updated");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _mediator.Send(new SoftDeleteEmployeeCommand(id));
            _logger.Log($"Deleted employee with ID {id}");
            return Ok($"Employee with ID {id} deleted");
        }
    }
}
