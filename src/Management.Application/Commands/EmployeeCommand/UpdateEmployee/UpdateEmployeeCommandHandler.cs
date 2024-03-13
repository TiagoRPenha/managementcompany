using AutoMapper;
using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Commands.EmployeeCommand.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);

            await _employeeRepository.UpdateAsync(employee);

            return Unit.Value;
        }
    }
}
