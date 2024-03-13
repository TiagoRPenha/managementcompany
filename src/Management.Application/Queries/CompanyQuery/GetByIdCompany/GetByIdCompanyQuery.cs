using Management.Application.ViewModels;
using MediatR;

namespace Management.Application.Queries.CompanyQuery.GetByIdCompany
{
    public class GetByIdCompanyQuery : IRequest<CompanyViewModel>
    {
        public GetByIdCompanyQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
