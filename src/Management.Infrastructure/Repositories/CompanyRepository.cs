using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using Management.Infrastructure.DbContextConfiguration;

namespace Management.Infrastructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ManagementContext context) : base(context)
        {
        }
    }
}
