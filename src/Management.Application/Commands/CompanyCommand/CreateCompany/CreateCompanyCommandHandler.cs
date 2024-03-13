using Management.Application.ViewModels;
using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Commands.CompanyCommand.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyViewModel>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyViewModel> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Address.Street, 
                                      request.Address.ResidenceNumber, 
                                      request.Address.Neighborhood, 
                                      request.Address.Complement, 
                                      request.Address.City,
                                      request.Address.State,
                                      request.Address.Country);

            var company = new Company(request.Name, address, request.Phone);

            await _companyRepository.CreateAsync(company);

            return new CompanyViewModel(company.Name, company.Address, company.Phone, company.IndActive);
        }
    }
}
