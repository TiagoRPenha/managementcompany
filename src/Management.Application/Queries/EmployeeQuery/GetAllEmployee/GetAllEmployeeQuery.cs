// <summary> GetAllEmployeeQuery, Class responsible for obtaining employees </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.ViewModels;
using MediatR;

namespace Management.Application.Queries.EmployeeQuery.GetAllEmployee
{
    public class GetAllEmployeeQuery : IRequest<List<EmployeeViewModel>>
    {
    }
}
