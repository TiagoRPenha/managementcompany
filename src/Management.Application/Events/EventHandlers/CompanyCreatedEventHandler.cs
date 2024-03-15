// <summary> CompanyCreatedEventHandler, Class responsible for listening to a specific company event </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Ardalis.GuardClauses;
using Management.Core.Interfaces.Repositories;

namespace Management.Application.Events.EventHandlers
{
    public class CompanyCreatedEventHandler : IEventHandler<CompanyCreatedEvent>
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyCreatedEventHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        /// <summary>
        /// Responsible for listening to a create or update company event
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public async Task HandleAsync(CompanyCreatedEvent @event)
        {
            Guard.Against.Null(@event);

            var company = await _companyRepository.GetByIdAsync(@event.Company.Id);

            if (company is not { })
            {
                await _companyRepository.CreateAsync(@event.Company);
            }
            else
            {
                await _companyRepository.UpdateAsync(@event.Company);
            }
        }
    }
}
