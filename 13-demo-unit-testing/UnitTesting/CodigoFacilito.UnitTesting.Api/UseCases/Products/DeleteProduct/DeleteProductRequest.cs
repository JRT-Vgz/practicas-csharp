using CodigoFacilito.UnitTesting.Api.Models.Results;

using MediatR;

namespace CodigoFacilito.UnitTesting.Api.UseCases.Products.DeleteProduct
{
    public record DeleteProductRequest(Guid Id): IRequest<Result>;
}
