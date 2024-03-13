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

        public async Task<EmployeeViewModel> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);

            await _employeeRepository.CreateAsync(employee);

            var employeeVw = _mapper.Map<EmployeeViewModel>(employee);

            //return new EmployeeViewModel(employee.Name, employee.Document, employee.Departament, employee.Role, employee.IndActive);

            return employeeVw;
        }
    }
}
