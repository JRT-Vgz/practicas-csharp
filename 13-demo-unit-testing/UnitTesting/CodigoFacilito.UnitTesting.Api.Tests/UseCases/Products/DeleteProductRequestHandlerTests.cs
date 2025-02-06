using Xunit;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using CodigoFacilito.UnitTesting.Api.Entities;
using CodigoFacilito.UnitTesting.Api.Repositories;
using CodigoFacilito.UnitTesting.Api.UseCases.Products.DeleteProduct;

namespace CodigoFacilito.UnitTesting.Api.Tests.UseCases.Products
{


    public class DeleteProductRequestHandlerTests
    {
        [Fact]
        public async Task When_ExistingProduct_Expected_ReturnsSuccess()
        {
            // Arrange
            Mock<IProductRepository> mockRepository = new();

            DeleteProductRequestHandler sut = new(mockRepository.Object);

            Guid id = Guid.NewGuid();

            DeleteProductRequest request = new(id); // Existing product Id


            mockRepository.Setup(repo => repo.GetProductByIdAsync(request.Id))
                          .ReturnsAsync(new Product { Id = id, Name = "Product", Description = "Description" });

            // Act
            var result = await sut.Handle(request, default);

            // Assert
            Assert.True(result.Succeeded);

        }

        [Fact]
        public async Task When_NonExistingProduct_Expected_ReturnsErrorMessage()
        {
            // Arrange
            Mock<IProductRepository> mockRepository = new();

            DeleteProductRequestHandler handler = new(mockRepository.Object);

            DeleteProductRequest request = new(Guid.NewGuid()); // Non-existing product Id


            mockRepository.Setup(repo => repo.GetProductByIdAsync(request.Id))
                          .ReturnsAsync((Product)null);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Equal("No existe el producto", result.Errors[0]);

        }
    }

}
