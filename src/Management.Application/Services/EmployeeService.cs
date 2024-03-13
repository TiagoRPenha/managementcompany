using AutoMapper;
using Management.Application.Commands.EmployeeCommand.CreateEmployee;
using Management.Application.Commands.EmployeeCommand.UpdateEmployee;
using Management.Application.Interfaces.Services;
using Management.Application.Queries.EmployeeQuery.GetAllEmployee;
using Management.Application.Queries.EmployeeQuery.GetByIdEmployee;
using Management.Application.ViewModels;
using MediatR;

namespace Management.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMediator _mediator;

        public EmployeeService(IMediator mediator)
        {
           _mediator = mediator;
        }

        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
            var query = new GetAllEmployeeQuery();

            return await _mediator.Send(query);
        }

        public async Task<EmployeeViewModel> GetByIdAsync(int employeeId)
        {
            var query = new GetByIdEmployeeQuery(employeeId);

            return await _mediator.Send(query);
        }

        public async Task<EmployeeViewModel> CreateAsync(CreateEmployeeCommand employee)
        {
            return await _mediator.Send(employee);
        }
 

        public async Task UpdateAsync(UpdateEmployeeCommand employee, int companyId)
        {
            await _mediator.Send(employee);
        }

        public async Task DeleteAsync(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
