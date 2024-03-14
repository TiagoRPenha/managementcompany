// <summary> DependencyInjectionConfiguration, Class responsible for configuring service dependency injection </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.Interfaces.Services;
using Management.Application.Services;
using Management.Core.Interfaces.Repositories;
using Management.Infrastructure.DbContextConfiguration;
using Management.Infrastructure.Repositories;

namespace Management.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        /// <summary>
        /// Method responsible for resolving service dependency injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
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
