// <summary> UpdateEmployeeCommand, Class responsible for update employee </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using MediatR;
using System.Text.Json.Serialization;

namespace Management.Application.Commands.EmployeeCommand.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Departament { get; set; }
        public string Role { get; set; }
        public bool IndActive { get; set; }
        public int CompanyId { get; set; }
    }
}
