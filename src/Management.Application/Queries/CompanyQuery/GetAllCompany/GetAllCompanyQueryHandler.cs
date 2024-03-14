// <summary> GetAllCompanyQueryHandler, Class implements GetAllCompanyQuery, accessing the database through the repository </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
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

        /// <summary>
        /// Method responsible for making the request
        /// </summary>
        /// <param name="request">Request object</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a list of <see cref="CompanyViewModel"/></returns>
        public async Task<List<CompanyViewModel>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetAllAsync();

            return companies.Select(p => new CompanyViewModel(p.Name, _mapper.Map<AddressViewModel>(p.Address), p.Phone, p.IndActive)).ToList();
        }
    }
}
