// <summary> ManagerMapping, Class responsible for mapping entities for use </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using AutoMapper;
using Management.Application.Commands.CompanyCommand.CreateCompany;
using Management.Application.Commands.CompanyCommand.UpdateCompany;
using Management.Application.Commands.EmployeeCommand.CreateEmployee;
using Management.Application.Commands.EmployeeCommand.UpdateEmployee;
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
            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();

            CreateMap<CompanyViewModel, CreateCompanyCommand>().ReverseMap();
        }
    }
}
