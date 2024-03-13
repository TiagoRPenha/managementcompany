using AutoMapper;
using Management.Application.ViewModels;
using Management.Core.Interfaces.Repositories;
using MediatR;

namespace Management.Application.Queries.EmployeeQuery.GetByIdEmployee
{
    public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQuery, EmployeeViewModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetByIdEmployeeQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeViewModel> Handle(GetByIdEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);

            return _mapper.Map<EmployeeViewModel>(employee);
        }
    }
}
