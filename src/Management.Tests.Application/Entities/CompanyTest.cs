using Management.Application.Interfaces.Services;
using Management.Core.Entities;
using Management.Core.Interfaces.Repositories;
using NSubstitute;
using System.Reflection;
using System.Security.Authentication;

namespace Management.Tests.Application.Entities
{
    public class CompanyTest
    {
        [Fact]
        public async void GetAllCompanies()
        {
            ////Arrange
            //const string title = "Company API - ";

            //List<Company> companies = new List<Company>()
            //{
            //    new Company
            //    {
            //        Id = 1,
            //        Name = title + Guid.NewGuid().ToString(),
            //        Phone = "9999999",
            //        Address = new Address("STREET One", "1", "CENTRO", "HOME", "FRANCA", "SÃO PAULO", "BRAZIL")
            //    },
            //    new Company
            //    {
            //        Id = 2,
            //        Name = title + Guid.NewGuid().ToString(),
            //        Phone = "1111111",
            //        Address = new Address("STREET Two", "2", "PORTINARI", "APARTMENT", "RIBEIRÃO PRETO", "SÃO PAULO", "BRAZIL")
            //    }
            //};

            //ICompanyRepository repository = Substitute.For<ICompanyRepository>();

            //foreach (var company in companies)
            //{
            //    repository.CreateAsync(company).Returns(company);
            //}

            //ICompanyService service = Substitute.For<ICompanyService>();

            ////Act
            ////foreach (var company in companies)
            ////{
            ////    service.CreateAsync(company);
            ////}

            //var companiesAll = await repository.GetAllAsync();

            ////Assert
            //Assert.NotNull(companiesAll);
            //Assert.Equal(companies.Count, companiesAll.Count);
        }

        [Fact]
        public void GetByIdCompany()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void CreateCompany()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void UpdateCompany()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void DeleteCompany()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}