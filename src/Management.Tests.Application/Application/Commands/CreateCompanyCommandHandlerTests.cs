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
        public async void CreateCompanyAsync()
        {
            //Arrange
            MapperConfiguration mapperConfig = new MapperConfiguration(cfg => {
                    cfg.AddProfile(new ManagerMapping());
            });

            IMapper mapper = new Mapper(mapperConfig);

            const string title = "Company API - ";

            var company = new Company
            {
                Name = title + Guid.NewGuid().ToString(),
                Phone = "9999999",
                Address = new Address("STREET One", "1", "CENTRO", "HOME", "FRANCA", "SÃO PAULO", "BRAZIL")
            };

            ICompanyRepository repository = Substitute.For<ICompanyRepository>();
            repository.CreateAsync(Arg.Any<Company>()).Returns(company);

            var createCompanyCommandHandler = new CreateCompanyCommandHandler(repository, mapper);

            var createCompanyCommand = mapper.Map<CreateCompanyCommand>(company);

            //Act
            var response = await createCompanyCommandHandler.Handle(createCompanyCommand, new CancellationToken());

            //Assert
            
            await repository.Received(1).CreateAsync(Arg.Any<Company>());
        }
    }
}
