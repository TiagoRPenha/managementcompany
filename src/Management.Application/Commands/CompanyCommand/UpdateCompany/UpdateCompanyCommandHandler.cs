using AutoMapper;
using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Commands.CompanyCommand.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var address = _mapper.Map<Address>(request.Address);

            var company = _companyRepository.GetByIdAsync(request.Id);

            var company = new Company(request.Name, address, request.Phone);

            await _companyRepository.UpdateAsync(company);

            return Unit.Value;
        }
    }
}
