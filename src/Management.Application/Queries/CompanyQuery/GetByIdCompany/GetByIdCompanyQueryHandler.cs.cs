using Management.Application.ViewModels;
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Queries.CompanyQuery.GetByIdCompany
{
    public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQuery, CompanyViewModel>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetByIdCompanyQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyViewModel> Handle(GetByIdCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id);

            var companyViewModel = new CompanyViewModel(company.Name, company.Address, company.Phone, company.IndActive);

            return companyViewModel;
        }
    }
}
