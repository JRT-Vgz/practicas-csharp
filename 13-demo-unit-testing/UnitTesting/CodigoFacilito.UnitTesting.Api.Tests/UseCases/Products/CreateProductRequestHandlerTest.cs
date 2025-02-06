using Xunit;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using CodigoFacilito.UnitTesting.Api.Entities;
using CodigoFacilito.UnitTesting.Api.Repositories;
using CodigoFacilito.UnitTesting.Api.UseCases.Products.CreateProduct;

namespace CodigoFacilito.UnitTesting.Api.Tests.UseCases.Products
{


    public class CreateProductRequestHandlerTests
    {
        [Fact]
        public async Task When_ValidRequest_Expected_ReturnsSuccess()
        {
            // Arrange
            Mock<IProductRepository> mockRepository = new();

            CreateProductRequestHandler sut = new(mockRepository.Object);

            CreateProductRequest request = new("Product Name", "Product Description");


            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.True(result.Succeeded);


        }

        [Theory]
        [InlineData("", "Product Description")]
        [InlineData("Product Name", "")]
        public async Task When_InvalidRequest_Expected_ReturnsErrorResponse(string name, string description)
        {
            // Arrange
            Mock<IProductRepository> mockRepository = new();

            CreateProductRequestHandler sut = new(mockRepository.Object);

            CreateProductRequest request = new(name, description);


            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.False(result.Succeeded);
        }

        [Fact]
        public async Task When_EmptyName_Expected_ReturnsErrorMessage()
        {
            // Arrange
            Mock<IProductRepository> mockRepository = new();

            CreateProductRequestHandler sut = new (mockRepository.Object);

            CreateProductRequest request = new (
                 "", // Empty name
                 "Product Description");
            

            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Equal("Debe ingresar un nombre.", result.Errors[0]);
        }

        [Fact]
        public async Task When_EmptyDescription_Expected_ReturnsErrorMessage()
        {
            // Arrange
            Mock<IProductRepository> mockRepository = new();

            CreateProductRequestHandler sut = new(mockRepository.Object);
            CreateProductRequest request = new(
                 "Product Name", 
                 "" // Empty Description
                 );

            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Equal("Debe ingresar una descripción.", result.Errors[0]);
        }
    }

}
