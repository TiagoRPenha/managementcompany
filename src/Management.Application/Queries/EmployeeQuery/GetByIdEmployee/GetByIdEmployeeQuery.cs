using Management.Application.ViewModels;
using MediatR;

namespace Management.Application.Queries.EmployeeQuery.GetByIdEmployee
{
    public class GetByIdEmployeeQuery : IRequest<EmployeeViewModel>
    {
        public GetByIdEmployeeQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
