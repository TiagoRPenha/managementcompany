// <summary> MigrationsConfiguration, Class responsible for using migrations in the MySQL instance available in Docker </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Infrastructure.DbContextConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Management.Api.Configurations
{
    public static class MigrationsConfiguration
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
