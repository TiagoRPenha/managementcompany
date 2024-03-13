using Management.Application.ViewModels;
using MediatR;

namespace Management.Application.Queries.CompanyQuery.GetAllCompany
{
    public class GetAllCompanyQuery : IRequest<List<CompanyViewModel>>
    {
    }
}
