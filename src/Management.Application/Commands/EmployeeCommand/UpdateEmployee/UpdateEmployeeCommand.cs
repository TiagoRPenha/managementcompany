using MediatR;

namespace Management.Application.Commands.EmployeeCommand.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Departament { get; set; }
        public string Role { get; set; }
        public bool IndActive { get; set; }
        public int CompanyId { get; set; }
    }
}
