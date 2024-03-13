using Management.Application.Interfaces.Services;
using Management.Application.Services;
using Management.Core.Interfaces.Repositories;
using Management.Infrastructure.DbContextConfiguration;
using Management.Infrastructure.Repositories;

namespace Management.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependenciesInjection(this IServiceCollection services)
        {
            services.AddScoped<ManagementContext>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
