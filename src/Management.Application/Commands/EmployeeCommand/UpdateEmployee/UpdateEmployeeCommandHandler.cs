// <summary> UpdateEmployeeCommandHandler, Class implements UpdateEmployeeCommand, accessing the database through the repository </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Commands.EmployeeCommand.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Method responsible for making the request
        /// </summary>
        /// <param name="request">Request object</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);

            employee.Name = request.Name;
            employee.Document = request.Document;
            employee.Departament = request.Departament;
            employee.Role = request.Role;
            employee.CompanyId = request.CompanyId;

            await _employeeRepository.UpdateAsync(employee);

            return Unit.Value;
        }
    }
}

