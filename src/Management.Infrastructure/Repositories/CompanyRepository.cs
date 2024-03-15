// <summary> Custom class to perform operations with the database referring to the Company context </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using Management.Infrastructure.DbContextConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Management.Infrastructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ManagementContext context) : base(context)
        {
        }

        /// <summary>
        /// Method responsible for returning all records of the co entity
        /// </summary>
        /// <returns>Returns a list of companies and addresses <see cref="Company"/></returns>
        public override async Task<List<Company>> GetAllAsync()
        {
            return await _entities.Include(p => p.Address).ToListAsync();
        }

        /// <summary>
        /// Method responsible for returning a specific record using the primary key
        /// </summary>
        /// <param name="id">>Primary Key Entity</param>
        /// <returns>Returns the record <see cref="Company"/></returns>
        public override async Task<Company> GetByIdAsync(int id)
        {
            return await _entities.Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
