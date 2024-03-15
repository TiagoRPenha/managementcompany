// <summary> EmployeeController, Class responsible for handling client requests </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
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

        /// <summary>
        /// EndPoint to get all employee records
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _employeeService.GetAllAsync();

            return Ok(response);
        }

        /// <summary>
        /// EndPoint to obtain a specific employee, according to their id
        /// </summary>
        /// <param name="employeeId">Employee identifier for get</param>
        /// <returns></returns>
        [HttpGet("{employeeId:int}")]
        public async Task<IActionResult> GetByIdAsync(int employeeId)
        {
            var response = await _employeeService.GetByIdAsync(employeeId);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// EndPoint to perform an employee registration
        /// </summary>
        /// <param name="employeeCommand">Employee data for creation</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateEmployeeCommand employeeCommand)
        {
            try
            {
                return Ok(await _employeeService.CreateAsync(employeeCommand));
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao realizar a operação de criação");
            }
        }

        /// <summary>
        /// EndPoint to update an employee record
        /// </summary>
        /// <param name="employeeCommand">Employee data for updating</param
        /// <param name="employeeId">Employee identifier for deletion</param
        /// <returns></returns>
        [HttpPut("{employeeId:int}")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateEmployeeCommand employeeCommand, int employeeId)
        {
            try
            {
                await _employeeService.UpdateAsync(employeeCommand, employeeId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao realizar a operação de atualização");
            }
        }

        /// <summary>
        /// EndPoint to logically remove an employee record
        /// </summary>
        /// <param name="employeeId">Employee identifier for deletion</param>
        /// <returns></returns>
        [HttpDelete("{employeeId:int}")]
        public async Task<IActionResult> DeleteAsync(int employeeId)
        {
            try
            {
                await _employeeService.DeleteAsync(employeeId);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest("Ocorreu um erro ao realizar a operação de deleção");
            }
        }
    }
}
