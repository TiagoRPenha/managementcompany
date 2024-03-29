﻿// <summary> CreateEmployeeCommand, Class responsible for created employee </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.ViewModels;
using MediatR;

namespace Management.Application.Commands.EmployeeCommand.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<EmployeeViewModel>
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Departament { get; set; }
        public string Role { get; set; }
        public bool IndActive { get; set; }
        public int CompanyId { get; set; }
    }
}
