using AutoMapper;
using Management.Application.ViewModels;
using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Commands.CompanyCommand.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyViewModel>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CompanyViewModel> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var address = _mapper.Map<Address>(request.Address);

            var company = new Company(request.Name, address, request.Phone);

            await _companyRepository.CreateAsync(company);

            return new CompanyViewModel(company.Name, _mapper.Map<AddressViewModel>(company.Address), company.Phone, company.IndActive);
        }
    }
}
