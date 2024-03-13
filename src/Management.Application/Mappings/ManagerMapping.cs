using AutoMapper;
using Management.Application.Commands.CompanyCommand.CreateCompany;
using Management.Application.Commands.EmployeeCommand.CreateEmployee;
using Management.Application.ViewModels;
using Management.Core.Entities;

namespace Management.Application.Mappings
{
    public class ManagerMapping : Profile
    {
        public ManagerMapping() 
        {
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
        }
    }
}
