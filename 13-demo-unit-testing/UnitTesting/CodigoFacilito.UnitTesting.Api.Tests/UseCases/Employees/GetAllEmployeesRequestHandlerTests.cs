using CodigoFacilito.UnitTesting.Api.Data;
using CodigoFacilito.UnitTesting.Api.Entities;
using CodigoFacilito.UnitTesting.Api.UseCases.Employees.GetAllEmployees;

using Microsoft.EntityFrameworkCore;

namespace CodigoFacilito.UnitTesting.Api.Tests.UseCases.Employees
{
    public class GetAllEmployeesRequestHandlerTests
    {

        [Fact]
        public async Task When_NotExistsEmployees_Expected_ResultSuccess()
        {
            // Arrange

            var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Nombre de la base de datos en memoria
                    .Options;

            AppDbContext context = new(options);

            GetAllEmployeesRequestHandler sut = new(context);

            GetAllEmployeesRequest request = new();


            // Act
            var result = await sut.Handle(request, default);

            // Assert

            Assert.True(result.Succeeded);

            Assert.Empty(result.Data.Employees);

        }



        [Fact]
        public async Task When_ExistsEmployees_Expected_ResultSuccess()
        {
            // Arrange

            var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Nombre de la base de datos en memoria
                    .Options;

            AppDbContext context = new(options);

            Employee employee = new()
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = ""
            };

            context.Employees.Add(employee);
            context.SaveChanges();


            GetAllEmployeesRequestHandler sut = new(context);

            GetAllEmployeesRequest request = new();


            // Act
            var result = await sut.Handle(request, default);

            // Assert

            Assert.True(result.Succeeded);

            Assert.NotEmpty(result.Data.Employees);

        }
    }
}
