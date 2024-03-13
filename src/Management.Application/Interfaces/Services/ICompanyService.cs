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
