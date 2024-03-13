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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _companyService.GetAllAsync();

            return Ok(response);
        }

        [HttpGet("{companyId:int}")]
        public async Task<IActionResult> GetByIdAsync(int companyId)
        {
            var response = await _companyService.GetByIdAsync(companyId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCompanyCommand companyCommand)
        {
            var company = await _companyService.CreateAsync(companyCommand);

            return Ok(company);
        }

        [HttpPut("{companyId:int}")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCompanyCommand companyCommand, int companyId)
        {
            await _companyService.UpdateAsync(companyCommand, companyId);

            return Ok();
        }

        [HttpDelete("{companyId:int}")]
        public async Task<IActionResult> DeleteAsync(int companyId)
        {
            return Ok();
        }
    }
}
