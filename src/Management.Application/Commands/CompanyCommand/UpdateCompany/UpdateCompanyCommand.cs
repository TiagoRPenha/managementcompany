using Management.Application.ViewModels;
using MediatR;

namespace Management.Application.Commands.CompanyCommand.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
