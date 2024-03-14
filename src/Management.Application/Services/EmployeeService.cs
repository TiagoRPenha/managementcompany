// <summary> EmployeeService, Class responsible for implementing the IEmployeeService interface </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
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

        /// <summary>
        /// Method responsible for returning all records of the co entity
        /// </summary>
        /// <returns>Returns a list of records <see cref="EmployeeViewModel"/></returns>
        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
            var query = new GetAllEmployeeQuery();

            return await _mediator.Send(query);
        }

        /// <summary>
        /// Method responsible for returning a specific record using the primary key
        /// </summary>
        /// <param name="employeeId">Primary Key Entity</param>
        /// <returns>Returns the record <see cref="EmployeeViewModel"/></returns>
        public async Task<EmployeeViewModel> GetByIdAsync(int employeeId)
        {
            var query = new GetByIdEmployeeQuery(employeeId);

            return await _mediator.Send(query);
        }

        /// <summary>
        /// Method responsible for creating the record in the database
        /// </summary>
        /// <param name="employee">Record to be created</param>
        /// <returns>Returns the created record <see cref="EmployeeViewModel"/></returns>
        public async Task<EmployeeViewModel> CreateAsync(CreateEmployeeCommand employee)
        {
            return await _mediator.Send(employee);
        }

        /// <summary>
        /// Method responsible for updating the record in the database
        /// </summary>
        /// <param name="employee">Record to be created</param>
        /// <param name="companyId">Primary Key Entity</param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateEmployeeCommand employee, int companyId)
        {
            employee.Id = companyId;

            await _mediator.Send(employee);
        }

        /// <summary>
        /// Method responsible for removing the record from the database
        /// </summary>
        /// <param name="employeeId">Primary Key Entity</param>
        /// <returns></returns>
        public async Task DeleteAsync(int employeeId)
        {
            await _mediator.Send(employeeId);
        }
    }
}
