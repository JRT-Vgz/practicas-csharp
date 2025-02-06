using Xunit;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CodigoFacilito.UnitTesting.Api.Entities;
using CodigoFacilito.UnitTesting.Api.Models.Results;
using CodigoFacilito.UnitTesting.Api.Repositories;
using CodigoFacilito.UnitTesting.Api.UseCases.Products.GetAllProducts;

namespace CodigoFacilito.UnitTesting.Api.Tests.UseCases.Products
{


    public class GetAllProductsRequestHandlerTests
    {
        [Fact]
        public async Task When_ExistingProducts_Expected_ReturnsSuccess()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();


            var products = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Product 1", Description = "Description 1" },
                new Product { Id = Guid.NewGuid(), Name = "Product 2", Description = "Description 2" },
                new Product { Id = Guid.NewGuid(), Name = "Product 3", Description = "Description 3" }
            };

            mockRepository.Setup(repo => repo.GetAllProductsAsync())
                          .ReturnsAsync(products);

            GetAllProductsRequestHandler sut = new(mockRepository.Object);
            GetAllProductsRequest request = new();

            // Act
            var result = await sut.Handle(request, default);

            // Assert

            Assert.True(result.Succeeded);
            Assert.Equal(3, result.Data.Products.Count());

            // Si es necesario, puede seguir comprobando el contenido de la respuesta
            Assert.Contains(result.Data.Products, p => p.Name == "Product 1");
            Assert.Contains(result.Data.Products, p => p.Name == "Product 2");
            Assert.Contains(result.Data.Products, p => p.Name == "Product 3");
        }

    }

}
