using CodigoFacilito.UnitTesting.Api.Models.Results;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Products.CreateProduct
{
    public record CreateProductRequest(string Name, string Description) : IRequest<Result<CreateProductResponse>>;
}
