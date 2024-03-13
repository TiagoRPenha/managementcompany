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
