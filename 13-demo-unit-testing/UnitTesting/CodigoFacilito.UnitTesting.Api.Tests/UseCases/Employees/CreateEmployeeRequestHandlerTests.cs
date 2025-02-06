using CodigoFacilito.UnitTesting.Api.Data;
using CodigoFacilito.UnitTesting.Api.UseCases.Employees.CreateEmployee;

using Microsoft.EntityFrameworkCore;

namespace CodigoFacilito.UnitTesting.Api.Tests.UseCases.Employees
{


    public class CreateEmployeeRequestHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_Expected_ReturnsSuccess()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            AppDbContext context = new(options);

            CreateEmployeeRequestHandler sut = new(context);

            CreateEmployeeRequest request = new("John", "Doe", "john.doe@example.com");

            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Succeeded);


            Assert.Equal(request.FirstName, result.Data.FirstName);
            Assert.Equal(request.LastName, result.Data.LastName);
            Assert.Equal(request.Email, result.Data.Email);

            // Chequeamos que el empleado fue agregado a la base de datos.
            // Esto es opcional.
            // Si el empleado no fue agregado a la base de datos, el test fallará.
            var employee = context.Employees.FirstOrDefault();
            Assert.NotNull(employee);
            Assert.Equal(request.FirstName, employee.FirstName);
            Assert.Equal(request.LastName, employee.LastName);
            Assert.Equal(request.Email, employee.Email);

        }

        [Theory]
        [InlineData("", "Doe", "john.doe@example.com")]
        [InlineData("John", "", "john.doe@example.com")]
        [InlineData("John", "Doe", "")]
        [InlineData("John", "Doe", "john.doe")]
        public async Task When_InvalidRequest_Expected_ReturnsError(string firstName, string lastName, string email)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            AppDbContext context = new(options);

            CreateEmployeeRequestHandler sut = new(context);

            CreateEmployeeRequest request = new(firstName, lastName, email);

            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.False(result.Succeeded);

        }

        [Fact]
        public async Task When_EmptyFirstName_Expected_ReturnsErrorMessage()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            AppDbContext context = new(options);

            CreateEmployeeRequestHandler sut = new(context);

            CreateEmployeeRequest request = new("", // Empty first name
                                                       "Doe",
                                                       "john.doe@example.com");


            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Equal("Debe ingresar el primer nombre del empleado.", result.Errors[0]);
        }


        [Fact]
        public async Task When_EmptyLastName_Expected_ReturnsErrorMessage()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            AppDbContext context = new(options);

            CreateEmployeeRequestHandler sut = new(context);

            CreateEmployeeRequest request = new("John",
                                                       "",// Empty last name
                                                       "john.doe@example.com");


            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.False(result.Succeeded);

            Assert.Equal("Debe ingresar el segundo nombre del empleado.", result.Errors[0]);
        }


        [Fact]
        public async Task When_EmptyEmail_Expected_ReturnsErrorMessage()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            AppDbContext context = new(options);

            CreateEmployeeRequestHandler sut = new(context);

            CreateEmployeeRequest request = new("John",
                                                       "Doe",
                                                       "");// Empty email


            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Equal("Debe ingresar el email del empleado.", result.Errors[0]);
        }


        [Fact]
        public async Task When_InvalidEmail_Expected_ReturnsErrorMessage()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            AppDbContext context = new(options);

            CreateEmployeeRequestHandler sut = new(context);

            CreateEmployeeRequest request = new("John",
                                                       "Doe",
                                                       "john.doe"); // Invalid email without @


            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Equal("Debe ingresar un email valido.", result.Errors[0]);
        }
    }
}
