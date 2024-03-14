using AutoMapper;
using Management.Application.Commands.CompanyCommand.CreateCompany;
using Management.Application.Mappings;
using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using NSubstitute;

namespace Management.Tests.Application.Application.Commands
{
    public class CreateCompanyCommandHandlerTests
    {
        [Fact]
        public async void CreateCompany()
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

            ICompanyRepository repository = Substitute.For<ICompanyRepository>();

            var createCompanyCommandHandler = new CreateCompanyCommandHandler(repository, mapper);

            var createCompanyCommand = mapper.Map<CreateCompanyCommand>(company);

            //Act
            var response = await createCompanyCommandHandler.Handle(createCompanyCommand, new CancellationToken());

            //Assert
            Assert.NotNull(response);
            Assert.Equal(company.Name, response.Name);
        }
    }
}
