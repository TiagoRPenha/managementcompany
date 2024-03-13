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

        public override async Task<List<Company>> GetAllAsync()
        {
            return await _entities.Include(p => p.Address).ToListAsync();
        }

        public override async Task<Company> GetByIdAsync(int id)
        {
            return await _entities.Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
