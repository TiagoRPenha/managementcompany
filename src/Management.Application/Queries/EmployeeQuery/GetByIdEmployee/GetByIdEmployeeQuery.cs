// <summary> GetByIdEmployeeQuery, Class responsible for obtaining the employee </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.ViewModels;
using MediatR;

namespace Management.Application.Queries.EmployeeQuery.GetByIdEmployee
{
    public class GetByIdEmployeeQuery : IRequest<EmployeeViewModel>
    {
        public GetByIdEmployeeQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
