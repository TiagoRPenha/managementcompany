using AutoMapper;
using Management.Application.ViewModels;
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Queries.CompanyQuery.GetAllCompany
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQuery, List<CompanyViewModel>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetAllCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyViewModel>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetAllAsync();

            return companies.Select(p => new CompanyViewModel(p.Name, _mapper.Map<AddressViewModel>(p.Address), p.Phone, p.IndActive)).ToList();
        }
    }
}
