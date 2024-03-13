using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Commands.CompanyCommand.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly ICompanyRepository _companyRepository;
        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Address.Street,
                                      request.Address.ResidenceNumber,
                                      request.Address.Neighborhood,
                                      request.Address.Complement,
                                      request.Address.City,
                                      request.Address.State,
                                      request.Address.Country);

            var company = new Company(request.Name, address, request.Phone);

            await _companyRepository.UpdateAsync(company);

            return Unit.Value;
        }
    }
}
