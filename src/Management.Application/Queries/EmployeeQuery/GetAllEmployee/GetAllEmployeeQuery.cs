using Management.Application.ViewModels;
using MediatR;

namespace Management.Application.Queries.EmployeeQuery.GetAllEmployee
{
    public class GetAllEmployeeQuery : IRequest<List<EmployeeViewModel>>
    {
    }
}
