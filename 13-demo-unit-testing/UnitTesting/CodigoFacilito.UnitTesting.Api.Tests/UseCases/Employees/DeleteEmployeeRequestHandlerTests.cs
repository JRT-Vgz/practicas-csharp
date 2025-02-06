using CodigoFacilito.UnitTesting.Api.Data;
using CodigoFacilito.UnitTesting.Api.Entities;
using CodigoFacilito.UnitTesting.Api.UseCases.Employees.DeleteEmployee;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoFacilito.UnitTesting.Api.Tests.UseCases.Employees
{
    public class DeleteEmployeeRequestHandlerTests
    {
        [Fact]
        public async Task When_ExistingEmployee_Expected_ReturnsSuccess()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            AppDbContext context = new(options);

            var id = Guid.NewGuid();

            Employee employee = new()
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                Email = ""
            };

            context.Employees.Add(employee);
            context.SaveChanges();



            DeleteEmployeeRequestHandler sut = new(context);

            DeleteEmployeeRequest request = new(id); // Existing employee Id

            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.True(result.Succeeded);

            // Chequeamos que el empleado fue eliminado de la base de datos.
            // Esto es opcional.
            // Si el empleado no fue eliminado de la base de datos, el test fallará.
            var remainingEmployees = context.Employees.ToList();
            Assert.Empty(remainingEmployees);

        }

        [Fact]
        public async Task When_NonExistingEmployee_Expected_ReturnsErrorMessage()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            AppDbContext context = new(options);

            DeleteEmployeeRequestHandler sut = new(context);

            DeleteEmployeeRequest request = new(Guid.NewGuid()); // Non-existing employee Id

            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Equal("No existe el empleado.", result.Errors[0]);



        }
    }
}
