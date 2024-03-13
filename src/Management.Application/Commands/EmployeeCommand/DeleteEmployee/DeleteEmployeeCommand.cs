using MediatR;

namespace Management.Application.Commands.EmployeeCommand.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<Unit>
    {
        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
