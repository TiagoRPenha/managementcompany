using AutoMapper;
using Management.Application.ViewModels;
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Queries.CompanyQuery.GetByIdCompany
{
    public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQuery, CompanyViewModel>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetByIdCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CompanyViewModel> Handle(GetByIdCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id);

            return _mapper.Map<CompanyViewModel>(company);
        }
    }
}
