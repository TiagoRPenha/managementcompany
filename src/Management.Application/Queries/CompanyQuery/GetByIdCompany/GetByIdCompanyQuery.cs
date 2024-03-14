// <summary> GetByIdCompanyQuery, Class responsible for obtaining the company </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
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
