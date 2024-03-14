// <summary> Custom class to perform operations with the database referring to the Employee context </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using Management.Infrastructure.DbContextConfiguration;

namespace Management.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ManagementContext context) : base(context)
        {
        }

        /// <summary>
        /// Method responsible for logically deleting an employee
        /// </summary>
        /// <param name="entity">Employee to be logically removed</param>
        public override async Task RemoveAsync(Employee entity)
        {
           await UpdateAsync(entity);
        }
    }
}
