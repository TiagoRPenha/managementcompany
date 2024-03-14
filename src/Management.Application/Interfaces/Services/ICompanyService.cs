// <summary> ICompanyService, Interface with declaration of common methods for application </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.Commands.CompanyCommand.CreateCompany;
using Management.Application.Commands.CompanyCommand.UpdateCompany;
using Management.Application.ViewModels;

namespace Management.Application.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<CompanyViewModel> CreateAsync(CreateCompanyCommand company);
        Task UpdateAsync(UpdateCompanyCommand company, int companyId);
        Task DeleteAsync(int companyId);
        Task<List<CompanyViewModel>> GetAllAsync();
        Task<CompanyViewModel> GetByIdAsync(int companyId);
    }
}
