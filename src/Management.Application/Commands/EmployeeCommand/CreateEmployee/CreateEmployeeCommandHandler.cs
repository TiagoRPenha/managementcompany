// <summary> CreateEmployeeCommandHandler, Class implements CreateEmployeeCommand, accessing the database through the repository </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using AutoMapper;
using Management.Application.ViewModels;
using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Commands.EmployeeCommand.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeViewModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Method responsible for making the request
        /// </summary>
        /// <param name="request">Request object</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EmployeeViewModel> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);

            await _employeeRepository.CreateAsync(employee);

            return _mapper.Map<EmployeeViewModel>(employee);
        }
    }
}
