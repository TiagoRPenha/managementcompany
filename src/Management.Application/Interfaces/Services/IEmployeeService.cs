// <summary> IEmployeeService, Interface with declaration of common methods for application </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.Commands.EmployeeCommand.CreateEmployee;
using Management.Application.Commands.EmployeeCommand.UpdateEmployee;
using Management.Application.ViewModels;

namespace Management.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeViewModel> CreateAsync(CreateEmployeeCommand employee);
        Task UpdateAsync(UpdateEmployeeCommand employee, int employeeId);
        Task DeleteAsync(int employeeId);
        Task<List<EmployeeViewModel>> GetAllAsync();
        Task<EmployeeViewModel> GetByIdAsync(int employeeId);
    }
}
