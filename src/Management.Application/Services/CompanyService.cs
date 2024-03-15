// <summary> CompanyService, Class responsible for implementing the ICompanyService interface </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.Commands.CompanyCommand.CreateCompany;
using Management.Application.Commands.CompanyCommand.UpdateCompany;
using Management.Application.Interfaces.Services;
using Management.Application.Queries.CompanyQuery.GetAllCompany;
using Management.Application.Queries.CompanyQuery.GetByIdCompany;
using Management.Application.ViewModels;
using MediatR;

namespace Management.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMediator _mediator;

        public CompanyService(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Method responsible for returning all records of the co entity
        /// </summary>
        /// <returns>Returns a list of records <see cref="CompanyViewModel"/></returns>
        public async Task<List<CompanyViewModel>> GetAllAsync()
        {
            var query = new GetAllCompanyQuery();

            return await _mediator.Send(query);
        }

        /// <summary>
        /// Method responsible for returning a specific record using the primary key
        /// </summary>
        /// <param name="companyId">Primary Key Entity</param>
        /// <returns>Returns the record <see cref="CompanyViewModel"/></returns>
        public async Task<CompanyViewModel> GetByIdAsync(int companyId)
        {
            var query = new GetByIdCompanyQuery(companyId);

            return await _mediator.Send(query);
        }

        /// <summary>
        /// Method responsible for creating the record in the database
        /// </summary>
        /// <param name="company">Record to be created</param>
        /// <returns>Returns the created record <see cref="CompanyViewModel"/></returns>
        public async Task<CompanyViewModel> CreateAsync(CreateCompanyCommand company)
        {
            return await _mediator.Send(company);
        }

        /// <summary>
        /// Method responsible for updating the record in the database
        /// </summary>
        /// <param name="company">Record to be created</param>
        /// <param name="companyId">Primary Key Entity</param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateCompanyCommand company, int companyId)
        {
            company.Id = companyId;

            await _mediator.Send(company);
        }

        /// <summary>
        /// Method responsible for removing the record from the database
        /// </summary>
        /// <param name="companyId">Primary Key Entity</param>
        /// <returns></returns>
        public async Task DeleteAsync(int companyId)
        {
            await _mediator.Send(companyId);
        }
    }
}
