// <summary> CompanyController, Class responsible for handling client requests </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.Commands.CompanyCommand.CreateCompany;
using Management.Application.Commands.CompanyCommand.UpdateCompany;
using Management.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        /// <summary>
        /// EndPoint to get all companies records
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _companyService.GetAllAsync();

            return Ok(response);
        }

        /// <summary>
        /// EndPoint to obtain a specific company, according to their id
        /// </summary>
        /// <param name="companyId">Company identifier for get</param>
        /// <returns></returns>
        [HttpGet("{companyId:int}")]
        public async Task<IActionResult> GetByIdAsync(int companyId)
        {
            var response = await _companyService.GetByIdAsync(companyId);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// EndPoint to perform an company registration
        /// </summary>
        /// <param name="companyCommand">Company data for creation</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCompanyCommand companyCommand)
        {
            try
            {
                return Ok(await _companyService.CreateAsync(companyCommand));
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao realizar a operação de criação");
            }
        }

        /// <summary>
        /// EndPoint to update an employee record
        /// </summary>
        /// <param name="companyCommand">Company data for updating</param
        /// <param name="companyId">Company identifier for deletion</param
        /// <returns></returns>
        [HttpPut("{companyId:int}")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCompanyCommand companyCommand, int companyId)
        {
            try
            {
                await _companyService.UpdateAsync(companyCommand, companyId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao realizar a operação de atualização");
            }
        }

        /// <summary>
        /// EndPoint to logically remove an company record
        /// </summary>
        /// <param name="companyId">Company identifier for deletion</param>
        /// <returns></returns>
        [HttpDelete("{companyId:int}")]
        public async Task<IActionResult> DeleteAsync(int companyId)
        {
            try
            {
                await _companyService.DeleteAsync(companyId);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest("Ocorreu um erro ao realizar a operação de deleção");
            }
        }
    }
}
