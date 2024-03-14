using AutoMapper;
using Management.Application.Commands.CompanyCommand.CreateCompany;
using Management.Application.Commands.EmployeeCommand.CreateEmployee;
using Management.Application.Mappings;
using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using NSubstitute;

namespace Management.Tests.Application.Application.Commands
{
    public class CreateEmployeeCommandHandlerTests
    {
        [Fact]
        public async void CreateEmployee()
        {
            //Arrange
            MapperConfiguration mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new ManagerMapping());
            });

            IMapper mapper = new Mapper(mapperConfig);

            const string title = "Company API - ";

            var company = new Company
            {
                Id = 1,
                Name = title + Guid.NewGuid().ToString(),
                Phone = "9999999",
                Address = new Address("STREET One", "1", "CENTRO", "HOME", "FRANCA", "SÃO PAULO", "BRAZIL")
            };

            var employee = new Employee
            {
                Name = "Employee Company",
                Document = "4789789789",
                Departament = "RH",
                Role = "Recruiter", 
                CompanyId = company.Id
            };

            ICompanyRepository companyRepository = Substitute.For<ICompanyRepository>();
            IEmployeeRepository employeeRepository = Substitute.For<IEmployeeRepository>();

            var createCompanyCommandHandler = new CreateCompanyCommandHandler(companyRepository, mapper);
            var createEmployeeCommandHandler = new CreateEmployeeCommandHandler(employeeRepository, mapper);

            var createCompanyCommand = mapper.Map<CreateCompanyCommand>(company);
            var createEmployeeCommand = mapper.Map<CreateEmployeeCommand>(employee);

            //Act
            var companyResponse = await createCompanyCommandHandler.Handle(createCompanyCommand, new CancellationToken());
            var employeeResponse = await createEmployeeCommandHandler.Handle(createEmployeeCommand, new CancellationToken());

            //Assert
            Assert.NotNull(employeeResponse);
            Assert.Equal(employee.Name, employeeResponse.Name);
        }
    }
}
