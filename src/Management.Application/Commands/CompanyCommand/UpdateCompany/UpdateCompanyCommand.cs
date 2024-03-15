// <summary> UpdateCompanyCommand, Class responsible for update company </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Application.ViewModels;
using MediatR;
using System.Text.Json.Serialization;

namespace Management.Application.Commands.CompanyCommand.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public AddressViewModel Address { get; set; }
        public bool IndActive { get; set; }
    }
}
