// <summary> GetAllCompanyQuery, Class responsible for obtaining companies </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.ViewModels;
using MediatR;

namespace Management.Application.Queries.CompanyQuery.GetAllCompany
{
    public class GetAllCompanyQuery : IRequest<List<CompanyViewModel>>
    {
    }
}
