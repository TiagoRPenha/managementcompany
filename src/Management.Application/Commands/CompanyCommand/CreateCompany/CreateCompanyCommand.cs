// <summary> CreateCompanyCommand, Class responsible for created company </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.ViewModels;
using MediatR;

namespace Management.Application.Commands.CompanyCommand.CreateCompany
{
    public class CreateCompanyCommand : IRequest<CompanyViewModel>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
