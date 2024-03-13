using AutoMapper;
using Management.Application.Commands.CompanyCommand.CreateCompany;
using Management.Application.Commands.CompanyCommand.UpdateCompany;
using Management.Application.Interfaces.Services;
using Management.Application.Queries.CompanyQuery.GetAllCompany;
using Management.Application.Queries.CompanyQuery.GetByIdCompany;
using Management.Application.ViewModels;
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMediator _mediator;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(IMediator mediator, ICompanyRepository companyRepository)
        {
            _mediator = mediator;
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyViewModel>> GetAllAsync()
        {
            var query = new GetAllCompanyQuery();

            return await _mediator.Send(query);
        }

        public async Task<CompanyViewModel> GetByIdAsync(int companyId)
        {
            var query = new GetByIdCompanyQuery(companyId);

            return await _mediator.Send(query);
        }

        public async Task<CompanyViewModel> CreateAsync(CreateCompanyCommand company)
        {
            return await _mediator.Send(company);
        }

        public async Task UpdateAsync(UpdateCompanyCommand company, int companyId)
        {
            var companyUpdate = await GetByIdAsync(companyId);

            if(companyUpdate != null)
            {
                company.Id = companyId;
            }

            await _mediator.Send(company);
        }

        public async Task DeleteAsync(int companyId)
        {

        }
    }
}
