using Management.Application.Commands.EmployeeCommand.CreateEmployee;
using Management.Application.Commands.EmployeeCommand.UpdateEmployee;
using Management.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _employeeService.GetAllAsync();

            return Ok(response);
        }

        [HttpGet("{employeeId:int}")]
        public async Task<IActionResult> GetByIdAsync(int employeeId)
        {
            var response = await _employeeService.GetByIdAsync(employeeId);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateEmployeeCommand employeeCommand)
        {
            var employee = await _employeeService.CreateAsync(employeeCommand);

            return Ok(employee);
        }

        [HttpPut("{employeeId:int}")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateEmployeeCommand employeeCommand, int employeeId)
        {
           await _employeeService.UpdateAsync(employeeCommand, employeeId);

           return Ok();
        }

        [HttpDelete("{employeeId:int}")]
        public async Task<IActionResult> DeleteAsync(int employeeId)
        {
            return Ok();
        }        
    }
}
