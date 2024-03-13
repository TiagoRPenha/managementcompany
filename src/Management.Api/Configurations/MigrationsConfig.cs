using Management.Infrastructure.DbContextConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Management.Api.Configurations
{
    public static class MigrationsConfig
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider.GetService<ManagementContext>();

                serviceDb.Database.Migrate();
            }
        }
    }
}
