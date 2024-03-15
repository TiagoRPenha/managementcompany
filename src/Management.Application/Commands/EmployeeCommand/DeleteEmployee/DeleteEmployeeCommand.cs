// <summary> DeleteEmployeeCommand, Class responsible for delete employee </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
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
