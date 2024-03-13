using Management.Application.Commands.CompanyCommand.CreateCompany;
using Management.Application.Commands.CompanyCommand.UpdateCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCompanyCommand companyCommand)
        {
            var company = await _mediator.Send(companyCommand);

            return Ok(company);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCompanyCommand companyCommand, int companyId)
        {
            await _mediator.Send(companyCommand);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int companyId)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllAsync(int companyId)
        {
            return Ok();
        }
    }
}
