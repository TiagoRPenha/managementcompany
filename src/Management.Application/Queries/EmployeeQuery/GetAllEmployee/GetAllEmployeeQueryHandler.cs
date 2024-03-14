// <summary> GetAllEmployeeQueryHandler, Class implements GetAllEmployeeQuery, accessing the database through the repository </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.ViewModels;
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Queries.EmployeeQuery.GetAllEmployee
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, List<EmployeeViewModel>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Method responsible for making the request
        /// </summary>
        /// <param name="request">Request object</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a list of <see cref="EmployeeViewModel"/></returns>
        public async Task<List<EmployeeViewModel>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync();

            return employees.Select(p => new EmployeeViewModel(p.Name, p.Document, p.Departament, p.Role, p.IndActive))
                            .Where(p => p.IndActive == true)
                            .OrderBy(p => p.Name)
                            .ToList();
        }
    }
}
