// <summary> ICompanyRepository, Interface that specializes the generic IRepository interface </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Core.Entities;

namespace Management.Core.Interfaces.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
    }
}
